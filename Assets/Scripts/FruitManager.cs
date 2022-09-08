using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text LevelClear;
    public Text totalFruits;
    public Text collectedFruits;

    public GameObject Transition;
    //private int total;

    private void Start()
    {
        //total = transform.childCount;
        //totalFruits.text = total.ToString();
        Invoke("CalculateTotal",0.1f);
    }
    private void CalculateTotal()
    {
        totalFruits.text = transform.childCount.ToString();

    }
    void Update()
    {
        AllFruitsCollected();
        collectedFruits.text = transform.childCount.ToString();
    }
    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            LevelClear.gameObject.SetActive(true);
            Invoke("SetActiveTransition", 1f);

        }
    }
    void SetActiveTransition()
    {
        Transition.SetActive(true);
        Invoke("ChangeScene", 1f);
    }
    void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1==4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        

    }
}
