using UnityEngine;
using System.Collections;

public class ShadowAI : MonoBehaviour { //inherit from MovingObject Class 

	public float shadowSpeed;

	Animator shadowAnim;

	//facing direction
	//public GameObject enemyGraphic;
	bool canFlip = true; //shadow can't turn if charging the player
	bool facingRight = false; //is shadow facing right? facing left by default
	float flipTime = 5f; //amount of time before shadow can flip
	float nextFlipChance = 0f; //when can shadow flip next? flips immediately by default

	//attacking
	public float chargeTime; //time after player is spotted before shadow runs toward player
	float startChargeTime; //what time will shadow start running?
	bool charging; //is the shadow charging toward player?
	Rigidbody2D shadowRB;


	// Use this for initialization
	 void Start () {
		shadowAnim = GetComponent<Animator> ();
		shadowRB = GetComponent<Rigidbody2D> ();
	}
		

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance) {
			if (Random.Range (0, 10) >= 5) {
				flip ();
			}
			nextFlipChance = Time.time + flipTime; //update next flip time
		}
	}

	//when player enters shadow's eyesight
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			//if shadow is facing right and player is on shadow's left, flip enemy
			if (facingRight && other.transform.position.x < transform.position.x) {
				flip ();
			}
			//if shadow is facing left and player is on shadow's right
			else if (!facingRight && other.transform.position.x > transform.position.x) {
				flip ();
			}
			canFlip = false; //keep running toward player, don't flip
			charging = true; //get ready to run toward the player
			startChargeTime = Time.time + chargeTime; //delay before charging
		}
	}

	//if player stays in shadow's line of sight
	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Player") {
			if (startChargeTime < Time.time) {
				if (!facingRight)
					shadowRB.AddForce (new Vector2 (-1, 0) * shadowSpeed);
				else 
					shadowRB.AddForce(new Vector2(1,0) * shadowSpeed);
				shadowAnim.SetBool ("isCharging", charging); //activate run animation
			}
		}
	}

	//if player exits shadow's line of sight
	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			canFlip = true; //shadow can start flipping back and forth again
			charging = false; //shadow no longer charges toward player
			shadowRB.velocity = new Vector2 (0f, 0f);
			shadowAnim.SetBool ("isCharging", charging); //set shadow back to idle
		}
	}
		
	void flip() {
		if (!canFlip) return; //if can't flip, return

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		theScale.y *= 1;
		theScale.z *= -1;
		transform.localScale = theScale;
		facingRight = !facingRight;
	}
}
