/*************************
* Name: Sim McQueen
* Date: 12/14/2020
* Desc: Platform controller for player
**************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float dashforce = 4;
    private float moveInput;
    private bool facingRight = true;

    private Rigidbody2D myRB;
    private Animator myAnim;
    //private CapsuleCollider2D myCC;

    private bool isGrounded;
    //public Transform groundCheck;
    //public float checkRadius;
    private int jumps;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            jumps = GameManager.JumpAmount;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRB.velocity = Vector2.up * GameManager.JumpHeight;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && jumps > 1)
        {
            myRB.velocity = Vector2.up * GameManager.JumpHeight;
            --jumps;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!(collision.gameObject.CompareTag("Banana")))
        {
            isGrounded = true;
            myAnim.SetBool("Grounded", true);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!(collision.gameObject.CompareTag("Banana")))
        {
            isGrounded = true;
            myAnim.SetBool("Grounded", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        myAnim.SetBool("Grounded", false);
    }

    //Runs once per physics update
    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius);

        moveInput = Input.GetAxisRaw("Horizontal");
        //set player velocity based on input
        myRB.velocity = new Vector2(moveInput * GameManager.Speed, myRB.velocity.y);

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(facingRight)
            {
                myRB.AddForce(transform.right * dashforce);
            }
            
        }
        if(moveInput == 0)
        {
            myAnim.SetBool("isWalking", false);
        }
        else
        {
            myAnim.SetBool("isWalking", true);
        }


        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    //flips the player and all children attached
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}