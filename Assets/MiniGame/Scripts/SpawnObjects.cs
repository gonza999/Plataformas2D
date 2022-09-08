using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] enemies;

    public float timeSpawn=1;
    public float repeatSpawnRange = 3;

    public Transform xRangeLeft;
    public Transform xRangeRight;
    public Transform yRangeUp;
    public Transform yRangeDown;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies",timeSpawn,repeatSpawnRange);
    }
    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);

        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x,xRangeRight.position.x),
            Random.Range(yRangeDown.position.y,yRangeUp.position.y),0);
        GameObject enemy = Instantiate(enemies[Random.Range(0,enemies.Length)],spawnPosition,gameObject.transform.rotation);
    }
}
