using UnityEngine;
using System.Collections;

public class ForestShadowAI : MonoBehaviour {

	public float enemySpeed = 1f;

	private Animator animator;

	//facing
	bool facingRight = false;
	float flipTime = 4f;
	float nextFlipChance = 0f;

	Rigidbody2D enemyRB;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance) {
			Flip ();
			nextFlipChance = Time.time + flipTime;
		}
	}

	void FixedUpdate () {
		transform.position += transform.position.normalized *
			enemySpeed * Time.deltaTime;
		animator.SetBool ("isPatrolling", true);
	}

	void Flip () {
		facingRight = !facingRight;
		enemySpeed *= -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		theScale.y *= 1;
		theScale.z *= -1;
		transform.localScale = theScale;
	}
}
