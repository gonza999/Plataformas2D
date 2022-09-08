using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformEffector2D platformEffector2D;

    public float startWaitTime;

    private float waitTime;

    private void Start()
    {
        //platformEffector2D.GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = startWaitTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime<=0)
            {
                platformEffector2D.rotationalOffset = 180f;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            platformEffector2D.rotationalOffset = 0;

        }
    }

}
