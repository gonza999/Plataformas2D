using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAtack : MonoBehaviour
{
    public Animator animator;

    public float distanceRaycast = 0.5f;

    private float cooldownAtack = 1.5f;

    private float actualCooldownAtack;

    public GameObject beeBullet;

    void Start()
    {
        actualCooldownAtack = 0;
    }

    void Update()
    {
        actualCooldownAtack -= Time.deltaTime;

        Debug.DrawRay(transform.position, Vector2.down, Color.red, distanceRaycast);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position,Vector2.down,distanceRaycast);

        if (hit2D.collider!=null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if (actualCooldownAtack<0)
                {
                    Invoke("LaunchBullet", 0.5f);
                    animator.Play("Atack");
                    actualCooldownAtack = cooldownAtack;
                }
            }
        }
    }

    void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
