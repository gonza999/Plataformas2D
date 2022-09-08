using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public AudioSource clip;
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.CompareTag("Player"))
        {
            //Debug.log();
            clip.Play();
            collision2D.transform.GetComponent<PlayerRespawn>().PlayerDamage();
        }
    }
}
