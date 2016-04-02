using UnityEngine;
using System.Collections;

public class ShadowDamage : MonoBehaviour {

	public float damage; //how much damage this shadow can do
	public float damageRate; //how often can the enemy do damage?
	public float pushBackForce; //how much player is pushed back after being hit

	float nextDamage; //when does damage occur next?

	// Use this for initialization
	void Start () {
		nextDamage = 0f; //damage is initially done immediately

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Player" && nextDamage < Time.time) {
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth> ();
			playerHealth.addDamage (damage);
			nextDamage = Time.time + damageRate; //offset for when damage occurs

			pushBack (other.transform);
		} 
	}

	void pushBack(Transform pushedObject) {
		//direction of the push
		Vector2 pushDirection = new Vector2 (0, (pushedObject.position.y - transform.position.y)).normalized;

		pushDirection *= pushBackForce; //give the object an actual force > 1
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero; //any movement currently acting on object are now null and void
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse); //explosive-based force
	}
}
