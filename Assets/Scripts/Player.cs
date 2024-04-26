using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private float jumpForce;

    private Rigidbody2D rb2d;
    private Animator animator;

    //private bool isJumpable;
    public bool isRunnning;
    private bool isHorizontal;
    private bool isVertical;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();

    }

    void Movement()
    {
        float horizontalMoviment = Input.GetAxis("Horizontal");
        
        float verticalMoviment = Input.GetAxis("Vertical");
        


        if (horizontalMoviment > 0 )
        {
            animator.SetBool("Right", true);
            isRunnning = true;
            rb2d.velocity = new Vector2(horizontalMoviment * speed, rb2d.velocity.y);
        }
        else if(horizontalMoviment < 0)
        {
            animator.SetBool("Left", true);
            isRunnning = true;
            rb2d.velocity = new Vector2(horizontalMoviment * speed, rb2d.velocity.y);
        }
        else
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            isRunnning = false;
        }

        if (verticalMoviment > -0)
        {
            animator.SetBool("Up", true);
            isRunnning = true;
            isVertical = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, verticalMoviment * speed);
        }
        else if (verticalMoviment < -0)
        {
            animator.SetBool("Down", true);
            isRunnning = true;
            isVertical = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, verticalMoviment * speed);
        }
        else
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            isRunnning = false;
        }





    }


    //void Jump()
    //{
    //    if (Input.GetButtonDown("Jump") && isJumpable)
    //    {
    //        rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground") && !isJumpable)
    //    {
    //        isJumpable = true;
    //        animator.SetBool("Jump", false);
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground") && isJumpable)
    //    {
    //        isJumpable = false;
    //        animator.SetBool("Jump", true);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //}

}