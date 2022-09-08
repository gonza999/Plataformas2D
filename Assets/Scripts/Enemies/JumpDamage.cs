using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;

    public AudioSource clip;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public float jumpForce=2.5f;

    public int life = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up*jumpForce);
            LosseLifeAndHit();
            clip.Play();
        }  
    }

    public void CheckLife()
    {
        if (life==0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie",0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
    public void LosseLifeAndHit()
    {
        life--;
        animator.Play("Hit");
        CheckLife();
    }
}
