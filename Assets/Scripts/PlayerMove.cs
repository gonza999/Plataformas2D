using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 4;

    public AudioSource clip;

    public float doubleJumpSpeed =2.5f;

    private bool canDoubleJump;

    private Rigidbody2D rigidbody2D;

    public bool betterJump = false;

    public float fallMultiplayer = 0.5f;

    public float lowJumpMultiplayer = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public GameObject dustLeft;
    public GameObject dustRight;

    public float dashCooldown;

    public GameObject dashParticle;

    public float dashForce = 30;

    bool isTouchingFront = false;

    bool wallSliding = false;

    public float wallSlidingSpped = 0.75f;

    bool isTouchingRight;
    bool isTouchingLeft;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, -1);
        dashCooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow) && !wallSliding)
        {
            if (ChechGround.isGrounded)
            {
                canDoubleJump = true;
                clip.Play();
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
            }
            else 
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump",true);
                        canDoubleJump = false;
                        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, doubleJumpSpeed);
                    }
                }
            }
        }

        if (!ChechGround.isGrounded)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (ChechGround.isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);

        }

        if (rigidbody2D.velocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }
        else if (rigidbody2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);

        }

        if (isTouchingFront && !ChechGround.isGrounded)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            animator.Play("Wall");
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Clamp(rigidbody2D.velocity.y,-wallSlidingSpped,float.MaxValue));
        }

    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !isTouchingLeft)
        {
            rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run",true);

            if (ChechGround.isGrounded)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);
            }
            if (Input.GetKey(KeyCode.LeftShift) && dashCooldown <= 0)
            {
                Dash();
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) && dashCooldown <= 0)
        {
            Dash();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !isTouchingRight)
        {
            rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

            if (ChechGround.isGrounded)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
            if (Input.GetKey(KeyCode.LeftShift) && dashCooldown <= 0)
            {
                Dash();
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }



        if (betterJump)
        {
            if (rigidbody2D.velocity.y < 0)
            {
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer) * Time.deltaTime;
            }

            if (rigidbody2D.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
            {
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
        }
    }

    public void Dash()
    {
        GameObject dashObject;
        dashObject = Instantiate(dashParticle, transform.position, transform.rotation);
        if (spriteRenderer.flipX == true)
        {
            rigidbody2D.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        }
        else
        {
            rigidbody2D.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);

        }

        dashCooldown = 2;
        Destroy(dashObject, 0.5f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("WallRight"))
        {
            isTouchingFront = true;
            isTouchingRight = true;

        }
        if (collision.transform.CompareTag("WallLeft"))
        {
            isTouchingFront = true;
            isTouchingLeft = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFront = false;
        isTouchingRight = false;
        isTouchingLeft = false;

    }
}
