using UnityEngine;
using UnityEngine.UI;

public class Skill3 : MonoBehaviour
{
    public static Skill3 Instance { get; private set; }
    [SerializeField]
    int numberOfProjectiles;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject projectile;

    float radius, moveSpeed;

    // Use this for initialization


    [Header("Skill3")]
    public Image skillImage3;
    public float cooldown3 = 8f;
    public bool isCooldown3 = false;
    public bool isLockSkill3;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        skillImage3.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        radius = 5f;
        moveSpeed = 5f;
        Skill_3();
    }

    public void Skill_3()
    {
        if (isCooldown3)
        {
            skillImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (skillImage3.fillAmount <= 0)
            {
                skillImage3.fillAmount = 1;
                isCooldown3 = false;
                GameObject.Find("explosion").GetComponent<Button>().interactable = true;
            }
        }
    }
}
