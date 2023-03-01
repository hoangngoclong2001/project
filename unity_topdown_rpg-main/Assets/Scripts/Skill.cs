using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public static Skill Instance { get; private set; }
    [SerializeField]
    int numberOfProjectiles;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject projectile;

    float radius, moveSpeed;

    // Use this for initialization


    [Header("Skill1")]
    public Image skillImage1;
    public float cooldown1 = 5f;
    public bool isCooldown1 = false;
    public bool isLockSkill1;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Instance = this;
            skillImage1.fillAmount = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        radius = 5f;
        moveSpeed = 5f;
        Skill1();
    }

    public void Skill1()
    {
        if (isCooldown1)
        {
            skillImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (skillImage1.fillAmount <= 0)
            {
                skillImage1.fillAmount = 1;
                isCooldown1 = false;
                GameObject.Find("Dash").GetComponent<Button>().interactable = true;
            }
        }
    }
}
