using UnityEngine;
using UnityEngine.UI;

public class Skill2 : MonoBehaviour
{
    public static Skill2 Instance { get; private set; }
    [SerializeField]
    int numberOfProjectiles;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject projectile;

    float radius, moveSpeed;

    // Use this for initialization


    [Header("Skill2")]
    public Image skillImage2;
    public float cooldown2 = 5f;
    public bool isCooldown2 = false;
    public bool isLockSkill2;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        skillImage2.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        radius = 5f;
        moveSpeed = 5f;
        Skill_2();
    }

    public void Skill_2()
    {
        if (isCooldown2)
        {
            skillImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (skillImage2.fillAmount <= 0)
            {
                skillImage2.fillAmount = 1;
                isCooldown2 = false;
                GameObject.Find("3arrows").GetComponent<Button>().interactable = true;
            }
        }
    }
}
