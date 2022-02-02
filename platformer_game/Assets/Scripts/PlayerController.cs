using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private int health = 3;
    private int numOfHearth = 3;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;


    public Joystick joystick;
    public float speed = 3;

    private bool facingRight = true;
    private Rigidbody2D rb;
    private float horizontalMove;
    private Animator animator;

    private bool isGrounded;
    public int jumpPower = 25;
    public float checkRadius;
    public Transform groundCheck;

    public LayerMask theGround;

    private Vector2 respawnPos;

    [SerializeField]
    private GameObject fallDetect;



    private Vector2 levelStartPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        levelStartPos = transform.position;
        respawnPos = levelStartPos;

    }


    private void HealthManage()
    {
        if (health > numOfHearth)
        {
            health = numOfHearth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }


            if (i < numOfHearth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);
        animator.SetBool("isJump", !isGrounded);
      //  horizontalMove = Input.GetAxisRaw("Horizontal");
          horizontalMove = joystick.Horizontal;
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);


    }

    public void JumpButton()
    {
        if (isGrounded)
        {
            animator.SetBool("isJump", true);
            Jump();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("FallDetect"))
        {
            health--;
            if (health == 0)
            {
                gameOver();
            }
            transform.position = respawnPos;
        }
        if (other.CompareTag("CheckPoint"))
        {

            respawnPos = transform.position;
            print("It is new Checkpoint");
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelEndController.instanse.SuccesEndLevel();
        }
    }

    private void gameOver()
    {
        Time.timeScale = 0;
        LevelEndController.instanse.FailedEndLevel();
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


        // if()
        fallDetect.transform.position = new Vector2(transform.position.x, fallDetect.transform.position.y);
        HealthManage();
    }


    void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    }
}
