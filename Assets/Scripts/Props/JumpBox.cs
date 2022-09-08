using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public GameObject brokenParts;

    public GameObject boxCollider;

    public Collider2D collider2D;

    public float jumpForce = 4;

    public int lifes = 1;

    public GameObject fruit;

    private void Start()
    {
        fruit.SetActive(false);
        fruit.transform.SetParent(FindObjectOfType<FruitManager>().transform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LoseLifeAndHit();
        }
    }

    public void LoseLifeAndHit()
    {
        lifes--;
        animator.Play("Hit");
        CheckLife();
    }

    public void CheckLife()
    {
        if (lifes<=0)
        {
            fruit.SetActive(true);
            brokenParts.SetActive(true) ;
            spriteRenderer.enabled = false;
            boxCollider.SetActive(false);
            collider2D.enabled = false;
            Invoke("DestroyBox",0.5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(transform.parent.gameObject);
    }
}
