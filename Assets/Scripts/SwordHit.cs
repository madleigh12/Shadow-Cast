using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {

	public float swordDamage;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Shadow") {
			ShadowHealth hurtShadow = other.gameObject.GetComponent<ShadowHealth> ();
			hurtShadow.addDamage (swordDamage);
		}
	}
}
