using UnityEngine;
using UnityEngine.UI;

public class Skill4 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Skill4 Instance { get; private set; }

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject projectile;

    float radius, moveSpeed;

    // Use this for initialization


    [Header("Skill4")]
    public Image skillImage4;
    public float cooldown4 = 3f;
    public bool isCooldown4 = false;
    public bool isLockSkill4;


    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
        skillImage4.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        radius = 5f;
        moveSpeed = 5f;
        Skill_4();
    }

    public void Skill_4()
    {
        if (isCooldown4)
        {
            skillImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;
            if (skillImage4.fillAmount <= 0)
            {
                skillImage4.fillAmount = 1;
                isCooldown4 = false;
                GameObject.Find("Shield").GetComponent<Button>().interactable = true;
            }
        }
    }
}
