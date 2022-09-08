using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public Joystick joystick;

    private float horizontalMove = 0f;
    public float runSpeedHorizontal = 2;
    public float runSpeed = 2;
    public float jumpSpeed = 4;

    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;

    private Rigidbody2D rigidbody2D;

    public SpriteRenderer SpriteRenderer;

    public Animator Animator;


    public GameObject dustLeft;
    public GameObject dustRight;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (horizontalMove<0)
        {
            SpriteRenderer.flipX = true;
            Animator.SetBool("Run", true);
            if (ChechGround.isGrounded)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);
            }
        }
        else if (horizontalMove>0)
        {
            SpriteRenderer.flipX = false;
            Animator.SetBool("Run", true);
            if (ChechGround.isGrounded)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
        }
        else
        {
            Animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (!ChechGround.isGrounded)
        {
            Animator.SetBool("Jump", true);
            Animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (ChechGround.isGrounded)
        {
            Animator.SetBool("Jump", false);
            Animator.SetBool("DoubleJump", false);
            Animator.SetBool("Falling", false);

        }

        if (rigidbody2D.velocity.y < 0)
        {
            Animator.SetBool("Falling", true);

        }
        else if (rigidbody2D.velocity.y > 0)
        {
            Animator.SetBool("Falling", false);

        }
    }
    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove,0,0)*Time.deltaTime*runSpeed;
    }

    public void Jump()
    {
        if (ChechGround.isGrounded)
        {
            canDoubleJump = true;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }
        else
        {
            if (canDoubleJump)
            {
                Animator.SetBool("DoubleJump", true);
                canDoubleJump = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, doubleJumpSpeed);
            }

        }
    }
}
