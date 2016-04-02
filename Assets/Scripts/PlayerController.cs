using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    bool facingRight = true;
    bool isJumping = false;
    public float Speed = 0f;
    private float move = 0f;
    public float jumpHeight;
    public float jumpSpeed;
    public GameObject FrontLegQuad;
    public GameObject BackLegQuad;
    public GameObject FrontLegBoot;
    public GameObject BackLegCalf;
    public GameObject FrontLegCalf;
    public GameObject BackLegBoot;
    public GameObject FuzzyScarf;
    public GameObject Hair1;
    public GameObject Hair2;
    public GameObject Hair3;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        { //walking left
            if (facingRight == true && !Input.GetKey(KeyCode.RightArrow))
            {
                Flip();

                //Adjust the sprite sorting order
                FrontLegQuad.GetComponent<SpriteRenderer>().sortingOrder = -1;
                BackLegQuad.GetComponent<SpriteRenderer>().sortingOrder = -1;
                FrontLegBoot.GetComponent<SpriteRenderer>().sortingOrder = 1;
                BackLegBoot.GetComponent<SpriteRenderer>().sortingOrder = 1;
                FuzzyScarf.GetComponent<SpriteRenderer>().sortingOrder = 1;
                Hair1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                Hair2.GetComponent<SpriteRenderer>().sortingOrder = 1;
                Hair3.GetComponent<SpriteRenderer>().sortingOrder = 1;
                BackLegCalf.GetComponent<SpriteRenderer>().sortingOrder = -1;
                FrontLegCalf.GetComponent<SpriteRenderer>().sortingOrder = -1;

            }
            animator.SetBool("Walking", true);

            if (Input.GetKeyUp(KeyCode.UpArrow))
            { // if the up key is released while the player is walking, then stop jumping

                //transform.Translate(Vector3.up * 12 * Time.deltaTime, Space.World);
                animator.SetBool("isJumping", false);
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        { //walking right
            if (facingRight == false)
            {
                Flip();

            }
            animator.SetBool("Walking", true);

            if (Input.GetKeyUp(KeyCode.UpArrow))
            { // if the up key is released while the player is walking, then stop jumping

                //transform.Translate(Vector3.up * 12 * Time.deltaTime, Space.World);
                animator.SetBool("isJumping", false);
            }

        }
        else
        {
            animator.SetBool("Walking", false);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        { //while up key is held down, player will continue to jump

            //transform.Translate(Vector3.up * 12 * Time.deltaTime, Space.World);
            animator.SetBool("isHiding", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("Walking", false);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        { //while up key is held down, player will continue to jump

            //transform.Translate(Vector3.up * 12 * Time.deltaTime, Space.World);
            animator.SetBool("isHiding", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        { //while up key is held down, player will continue to jump

            animator.SetBool("isJumping", true);
            transform.Translate(Vector3.up * jumpHeight * Time.deltaTime, Space.World);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        { //When up key is released, player stops jumping

            animator.SetBool("isJumping", false);

        }
    }

    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        theScale.y *= 1;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Vine")){
            transform.parent = collision.gameObject.transform;
        }
    }
}