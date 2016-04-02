using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	public GameObject deathFX;
	float currentHealth;

	PlayerController controlMovement;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addDamage(float damage) {
		if (damage <= 0)
			return;
		currentHealth -= damage;

		if (currentHealth <= 0)
			makeDead ();
	}

	public void makeDead() {
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
