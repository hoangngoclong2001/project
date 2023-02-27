using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI healthText;
    [SerializeField]
    GameObject health;
    [SerializeField]
    TextMeshProUGUI levelText;
    [SerializeField]
    GameObject dash;
    [SerializeField]
    GameObject bigbom;
    [SerializeField]
    GameObject small;
    [SerializeField]
    GameObject shield;
    [SerializeField]
    GameObject pause;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    GameObject player;
    int score;
    const string ScorePrefix = "Score: ";
    // Start is called before the first frame update
    void Start()
    {
        //Skill position
        //dash.transform.position = new Vector3(Screen.width - 300f, 80f, 0);
        ////dash.transform.GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 2f);
        //bigbom.transform.position = new Vector3(Screen.width - 120f, 120f, 0);
        ////bigbom.transform.GetComponent<RectTransform>().localScale = new Vector3(2.5f, 2.5f, 2.5f);
        //small.transform.position = new Vector3(Screen.width - 265f, 265f, 0);
        ////small.transform.GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 2f);
        //shield.transform.position = new Vector3(Screen.width - 100f, 350f, 0);
        ////shield.transform.GetComponent<RectTransform>().localScale = new Vector3(2f,2f,2f);

        //pause.transform.position = new Vector3(Screen.width - 200, Screen.height - 100f, 0);
        //healthText.transform.position = new Vector3(Screen.width * 0.01f + 130f, Screen.height - 80f, 0);
        //health.transform.position = new Vector3(Screen.width * 0.01f, Screen.height -120f, 0);
        //scoreText.transform.position = new Vector3(Screen.width * 0.01f + 130f, Screen.height - 160f, 0);
        //levelText.transform.position = new Vector3(Screen.width * 0.01f + 110f, Screen.height - 200f, 0);
        int score = 0;
        scoreText.text = ScorePrefix + score.ToString();
        PlayerHealth p = player.GetComponent<PlayerHealth>();
        healthText.text = p.GetMaxHealth() + "/" + p.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }
}
