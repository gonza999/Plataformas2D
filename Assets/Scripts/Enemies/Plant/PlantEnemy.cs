using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;

    public float waitTimeToAtack=3;

    public Animator animator;

    public GameObject bulletPrefab;

    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimeToAtack;
    }

    private void Update()
    {
        if (waitedTime<=0)
        {
            waitedTime = waitTimeToAtack;
            animator.Play("Attack");
            Invoke("LaunchBullet",0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab,launchSpawnPoint.position,launchSpawnPoint.rotation);
    }
}
