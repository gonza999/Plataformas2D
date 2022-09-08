using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownObject : MonoBehaviour
{
    public float speed = 1;

    private void Start()
    {
        Destroy(gameObject,5);
    }
    private void Update()
    {
        transform.position += -transform.up*Time.deltaTime*speed;
    }
}
