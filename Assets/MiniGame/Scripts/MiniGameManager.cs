using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public Text pointsText;
    public float points;
    public Text pointsMaxText;
    public float pointsMax;

    private void Start()
    {
        pointsMax = PlayerPrefs.GetFloat("MaxPoints");
        pointsMaxText.text = pointsMax.ToString("0.00");
    }

    private void Update()
    {
        points += Time.deltaTime;
        pointsText.text = points.ToString("0.00");

        if (pointsMax<points)
        {
            PlayerPrefs.SetFloat("MaxPoints",points);
            pointsMax = points;
            pointsMaxText.text = points.ToString("0.00");
        }
    }
}
