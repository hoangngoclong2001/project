using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Sse4_2;

public class PlayerHealth : MonoBehaviour {
    private float health = 0f;
	[SerializeField] private float maxHealth = 100f;
	[SerializeField] private Slider healthSlider;
    [SerializeField] public GameObject gamover;
    private bool shiel = false;
    public GameObject shied;
    [SerializeField] public AudioSource she;
    [SerializeField]
    TextMeshProUGUI healthText;
    private void Start() {
		health = maxHealth;
		healthSlider.maxValue = maxHealth;
        gamover.SetActive(false);
    }

    public void Shield()
    {
        if (!shiel )
        {
            she.Play();
            shied.SetActive(true);
            shiel = true;
            Invoke("Noshield", 3f);
        }
        if(Skill4.Instance!=null)
        Skill4.Instance.isCooldown4 = !Skill4.Instance.isCooldown4;
        GameObject.Find("Shield").GetComponent<Button>().interactable = false;
    }
    public void Noshield()
    {
        shied.SetActive(false);
        shiel = false;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetHealth()
    {
        return health;
    }
    public void UpdateHealth(float mod) {
		if(shiel == false) { 
		    health += mod;

		    if (health > maxHealth) {
			    health = maxHealth;
		    } else if (health <= 0f) {
			    health = 0f;
			    healthSlider.value = health;
			    Destroy(gameObject);
                gamover.SetActive(true);
                Skill4.Instance.skillImage4.fillAmount = 0;
            }
        }
        healthText.text = GetHealth() + "/" + GetMaxHealth();
    }

   

    public void AddHealth(float x)
	{
		this.maxHealth += x;
		this.health += x;
		healthSlider.maxValue = this.maxHealth;
        healthText.text = GetHealth() + "/" + GetMaxHealth();
    }

	private void OnGUI() {
		float t = Time.deltaTime / 1f;
		healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
	}
}
