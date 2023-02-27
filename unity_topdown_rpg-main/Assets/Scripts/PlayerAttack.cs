using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] GameObject ArrowPrefab;
	[SerializeField] SpriteRenderer ArrowGFX;
	[SerializeField] Transform Bow;
    public GameObject player;

    
	[SerializeField] float BowPower;

    [SerializeField] public AudioSource arrow;
	
	float BowCharge;
	bool CanFire = true;
    float nextFire = 0;

	private void Start() {
	
	}

	private void Update() {
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        if (allEnemies != null && Time.time > nextFire)
        {
            FireBow();
            nextFire = Time.time + 0.5f;
        }
    }

    public void FireBow() {
        ArrowGFX.enabled = true;
        BowCharge += Time.deltaTime;

        float ArrowSpeed = 0.5f + BowPower;
		float ArrowDamage = 0.5f * BowPower;

        Enemy closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {

            Vector3 vectorToTarget = player.transform.position - closestEnemy.transform.position;

            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90f;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);

            Arrow Arrow = Instantiate(ArrowPrefab, Bow.position, rot).GetComponent<Arrow>();
            Arrow.ArrowVelocity = ArrowSpeed;
            Arrow.ArrowDamage = ArrowDamage;

            arrow.Play();
            CanFire = false;
            ArrowGFX.enabled = false;
        }
    }
    public void LevelUp()
    {
        this.BowPower *= 1.1f;
    }
    Enemy FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");

        if(allEnemies!=null) { 
        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - player.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        }
        return closestEnemy;
    }
}
