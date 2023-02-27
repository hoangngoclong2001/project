using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float speed;


    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;
    private Rigidbody2D rigidbody;
    private Vector3 worldLocation;
    private Vector3 Location;
    void Start()
    {
        minSpawnX = 0;
        maxSpawnX = Screen.width - 50;
        minSpawnY = 0;
        maxSpawnY = Screen.height - 50;
        rigidbody = GetComponent<Rigidbody2D>();
        Location = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
        worldLocation = Camera.main.ScreenToWorldPoint(Location);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != worldLocation)
        {
            transform.position = Vector3.MoveTowards(new Vector2(transform.position.x, transform.position.y), worldLocation, Time.deltaTime * speed);
        }
        else
        {
            Location = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);
            worldLocation = Camera.main.ScreenToWorldPoint(Location);
        }
    }
}
