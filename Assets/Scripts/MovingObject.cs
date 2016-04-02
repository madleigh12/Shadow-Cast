using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

	public float moveTime = 0.1f;
	public LayerMask blockingLayer;  //determine if a space is ok to move on

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D; //store composite reference to the body
	private float inverseMoveTime; //make movement calcs more efficient

	// Use this for initialization
	protected virtual void Start () { //can be overwritten by inheriting classes
		boxCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime;
	}

	protected bool Move (int xDir, int yDir, out RaycastHit2D hit) {
		Vector2 start = transform.position; 
		Vector2 end = new Vector2 (xDir, yDir);

		boxCollider.enabled = false; //disable attached boxCollider so we don't hit our own collider
		hit = Physics2D.Linecast(start, end ,blockingLayer);

		//check if anything was hit
		if (hit.transform == null) {
			StartCoroutine (SmoothMovement (end));
			return true;
		}
		return false;
	}

	protected IEnumerator SmoothMovement (Vector3 end) {
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrRemainingDistance > float.Epsilon) {
			//moves object in a straight line
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition (newPosition);
			yield return null; //wait for a frame before re-evaluating the condition of the loop
		}
	}

	protected virtual void AttemptMove <T> (int xDir, int yDir)
		where T : Component {
		RaycastHit2D hit;
		bool canMove = Move (xDir, yDir, out hit); //true if move was successful

		if (hit.transform == null) //if nothing was hit by the linecast
			return;

		//get component reference attached to the object that was hit
		T hitComponent = hit.transform.GetComponent<T> ();

		//if can't move and moving object is blocked and hit something it can interact with
		if (!canMove && hitComponent != null) {
			OnCantMove (hitComponent);
		}
	} 


	//The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
	//OnCantMove will be overriden by functions in the inheriting classes.
	protected abstract void OnCantMove <T> (T component) 
			where T : Component;
	
}
