using UnityEngine;
using System.Collections;

public class ShadowHealth : MonoBehaviour {

	public float enemyMaxHealth; //maximum amount of health per shadow
	public GameObject deathFX;

	private float currentHealth; //current value of shadow's health


	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addDamage (float damage) {
		currentHealth -= damage;
		if (currentHealth <= 0)
			makeDead ();
	}

	void makeDead () { //put death animation/related death stuff here
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy(gameObject); //destroy shadow
	}
}
