using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    private float checkPointPositionX, checkPointPositionY;

    public Animator animator;
    void Start()
    {
        life = hearts.Length;
        if (PlayerPrefs.GetFloat("CheckPointPositionX")!=0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("CheckPointPositionX"),
                PlayerPrefs.GetFloat("CheckPointPositionY"));
        }
    }
    private void CheckLife()
    {
        if (life<1)
        {
            animator.Play("Hit");
            Destroy(hearts[0].gameObject);
            Invoke("ChangeScene", 0.2f);

        }
        else if (life<2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");

        }
        else if (life < 3)
        {
            animator.Play("Hit");
            Destroy(hearts[2].gameObject);
        }
    }
    public void ReachedChechPoint(float x,float y)
    {
        PlayerPrefs.SetFloat("CheckPointPositionX",x);

        PlayerPrefs.SetFloat("CheckPointPositionY", y);
    }

    public void PlayerDamage()
    {
        life--;
        CheckLife();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
