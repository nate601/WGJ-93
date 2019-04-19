using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoring : MonoBehaviour
{
    private int currentScore;

    public static Scoring instance;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple scoring scripts located");
            Destroy(this);
        }
    }

    public void UpdateScore(int modAmnt)
    {
        currentScore += modAmnt;
        scoreText.text = "Score: " + currentScore;
    }



}
