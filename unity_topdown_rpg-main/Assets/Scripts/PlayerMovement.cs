using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5f;
    int numberOfProjectiles;
    public Rigidbody2D rb;
    [SerializeField] Transform hand;
    private float activeMoveSpeed = 5f;
    public GameObject generade;
    public GameObject player;
   
    [SerializeField]
    GameObject projectile;

    Vector2 startPoint;


    float radius;
    float rotationModifier;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    private bool isdash = false;
    private bool isbomb = false;
    private bool ismutiple = false;
    private bool shiel = false;
    public GameObject shied;

    Vector2 movement;


    public void onClickDash()
    {
        
        isdash = true;
        Skill1.Instance.isCooldown1 = !Skill1.Instance.isCooldown1;
        GameObject.Find("Dash").GetComponent<Button>().interactable = false;
    }
    public void onClickMutiple()
    {
        ismutiple = true;
        Skill2.Instance.isCooldown2 = !Skill2.Instance.isCooldown2;
        GameObject.Find("3arrows").GetComponent<Button>().interactable = false;
    }
    public void onClickGen()
    {
        isbomb = true;
        Instantiate(generade, transform.position, Quaternion.identity);
        Skill3.Instance.isCooldown3 = !Skill3.Instance.isCooldown3;
        GameObject.Find("explosion").GetComponent<Button>().interactable = false;
    }
    

    public void Movement()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
        
    }

    public void Start()
    {
        
    }
        public void Update() {
        Movement();
        closet();
        dash();
        if (Input.GetKeyDown(KeyCode.H) && isdash == false)
        {
            onClickDash();
        }
        else if (Input.GetKeyDown(KeyCode.J) && isbomb == false)
        {
            onClickGen();
        }
        else if (Input.GetKeyDown(KeyCode.K) && isbomb == false)
        {
            onClickMutiple();

        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.deltaTime);
    }
    void dash()
    {
        if (isdash == true)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        isdash = false;
    }
    void rotateToTarget(Enemy enemy)
    {
        if (player != null && enemy!= null)
        {
            Vector3 vectorToTarget = player.transform.position - enemy.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 180f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10f);
        }
    }
    public void closet()
    {
    
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (Enemy currentEnemy in allEnemies)
        {
            currentEnemy.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.12f, 0f);
            float distanceToEnemy = (currentEnemy.transform.position - player.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy && distanceToEnemy != 0)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        if (closestEnemy != null)
            closestEnemy.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.12f, 0.8f);

        rotateToTarget(closestEnemy);
    }

    public void AddSpeed()
    {
        this.moveSpeed *= 1.1f;
    }
}
   


