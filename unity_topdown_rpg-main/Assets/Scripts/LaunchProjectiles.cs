using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchProjectiles : MonoBehaviour
{
    [SerializeField]
    int numberOfProjectiles;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject projectile;

    Vector2 startPoint;

    float radius, moveSpeed;

    // Use this for initialization
    private bool ismutiple = false;

    void Start()
    {
        radius = 5f;
        moveSpeed = 5f;
    }
    public void onClickMutiple()
    {
        ismutiple = true;
        Skill2.Instance.isCooldown2 = !Skill2.Instance.isCooldown2;
        GameObject.Find("3arrows").GetComponent<Button>().interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (ismutiple == true)
        {
            startPoint = player.transform.position;
            SpawnProjectiles(numberOfProjectiles);
            ismutiple = false;
        }
       
    }

    void SpawnProjectiles(int numberOfProjectiles)
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {

            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

            var proj = Instantiate(projectile, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }
}
