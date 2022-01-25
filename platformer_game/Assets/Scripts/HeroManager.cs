using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public float speed = 10;

    private bool facingRight = true;
    private Rigidbody2D rb;
    private float horizontalMove;
    private Animator animator;

    private bool isGrounded;
    public int jumpPower = 20;
    public float checkRadius;
    public Transform groundCheck;

    public LayerMask theGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }



    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);
          animator.SetBool("isJump", !isGrounded);
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);


    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        
       
        if (horizontalMove > 0 && !facingRight)
        {
            FlipPlayer();
        }

        if (horizontalMove < 0 && facingRight)
        {
            FlipPlayer();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("isJump", true);
            Jump();
        }

        // if()


    }

   
    void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    }
}
