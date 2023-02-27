using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genrade : MonoBehaviour
{
    private Vector3 targetPos;
    public float speed = 5;
    public GameObject explosion;
    public float radius = 1.5f;
    
    void Start()
    {
        targetPos = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 0)
        {
            speed -= Random.Range(.3f, .25f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);


        }
        else if (speed < 0)
        {
            speed = 0;

        }
    }
    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] enemyit = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D col in enemyit)
        {
            if (col.tag == "Enemy")
            {

                
                StartCoroutine(Explode(0));
                Enemy enemy = col.gameObject.GetComponent<Enemy>();

                enemy.TakeDamageBomb(10f);
               

            }

        }
    }

}