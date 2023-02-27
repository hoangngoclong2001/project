using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI level;

    Timer spawnTimer;

    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;
    // Start is called before the first frame update
    void Start()
    {
        var width = Screen.width - 100;
        var height = Screen.height - 100;
        minSpawnX = 0;
        maxSpawnX = Screen.width;
        minSpawnY = 0;
        maxSpawnY = Screen.height;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 5;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnBear();

            spawnTimer.Duration = 2;
            spawnTimer.Run();
        }
    }

    public void SpawnBear()
    {
        int score = Convert.ToInt32(Regex.Replace("0" + scoreText.text, "\\D+", ""));
        Vector3 Location = new Vector3(UnityEngine.Random.Range(minSpawnX, maxSpawnX), UnityEngine.Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(Location);


        GameObject ball = Instantiate(prefabBall) as GameObject;
        ball.GetComponent<Enemy>().HealthLevel();
        ball.transform.position = worldLocation;
        var ilevel = Convert.ToInt32(Regex.Replace("0" + level.text, "\\D+", ""));
        if (score / 20f > ilevel)
        {
            level.text = "Level: " + (ilevel + 1);
            var gobs = GameObject.FindGameObjectsWithTag("Enemy");
            var x = gobs[gobs.Length - 1];
            x.GetComponent<Enemy>().Upgrade(score);
            x.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().AddHealth(100f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().AddSpeed();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().LevelUp();
        }
    }
}
