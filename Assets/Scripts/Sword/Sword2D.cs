using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword2D : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public Animator animator;
    private SpriteRenderer playerSpriteRenderer;
    public GameObject swordParent;
    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (playerSpriteRenderer.flipX)
        {
            swordParent.transform.rotation = Quaternion.Euler(0,-180,0);
        }
        else
        {
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Attack()
    {
        animator.Play("Attack");
        boxCollider2D.enabled = true;
        Invoke("DisableAttack",0.5f);
    }

    private void DisableAttack()
    {
        boxCollider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<JumpDamage>().LosseLifeAndHit();
            boxCollider2D.enabled = true;
        }
    }
}
