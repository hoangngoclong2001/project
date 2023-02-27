using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3f;
    [Header("Attack")]
    [SerializeField] private float attackDamage = 15f;
    [SerializeField] private float attackSpeed = 2f;
    private float canAttack;

    [Header("Health")]
    private float health;
    [SerializeField] private float maxHealth;
    [SerializeField]

    private bool explosion;

    private Transform target;
    private Transform target2;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Color[] colors;

    public GameObject shield;

    private void Start()
    {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
    }
    public void HealthLevel()
    {
        health += 10f;
    }
    [SerializeField] public AudioSource arrow;
    public void TakeDamageBomb(float dmg)
    {
        if (health > 0 )
        {
            
            health -= dmg;
            StartCoroutine(SpeedBoostCoroutine());

            Debug.Log("Enemy Health: " + health);
            
        }
        if (health <= 0)
        {

            Destroy(gameObject);
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoint(1);

        }
    }
    private IEnumerator SpeedBoostCoroutine()
    {
        speed = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 1, 1);
        yield return new WaitForSeconds(3f);
        speed = 3f;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    public void TakeDamage(float dmg)
    {
        if (health > 0)
        {

            health -= dmg;
            Debug.Log("Enemy Health: " + health);
        }
        if (health <= 0)
        {

            Destroy(gameObject);
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoint(1);

        }
    }
    private bool shiel = false;
    public void UpdateShield()
    {
        shiel = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && shiel )
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && shiel)
        {
            if (attackSpeed <= canAttack )
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (Vector2.Distance(transform.position, target.position) > 0.5f)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else
        {
            Debug.Log("Target destroy");
        }
        UpdateShield();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] enemyit = Physics2D.OverlapCircleAll(transform.position, 10f);
        foreach (Collider2D col in enemyit)
        {
            if (col.tag == "Genrade")
            {

                Enemy enemy = col.gameObject.GetComponent<Enemy>();
                speed = 0f;

            }

        }
    }
    public void Upgrade(int point)
    {
        Debug.Log("upgrade" + point);
        this.speed = 3f + point * 1f / 15;
        this.attackDamage = 10f + point * 1f;
        this.attackSpeed = 2f;
        this.maxHealth = 30 * (point / 10) + 30;
        gameObject.GetComponent<SpriteRenderer>().sprite = this.sprites[(point / 20 - 1) % (this.sprites.Length)];
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = this.sprites[(point / 20 - 1) % (this.sprites.Length)];
        gameObject.GetComponent<SpriteRenderer>().color = this.colors[(point / 20 - 1) % (this.colors.Length)];
    }

}