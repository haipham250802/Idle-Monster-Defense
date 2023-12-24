using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore(int increase)
    {
        score += increase;
        UpdateScoreText();
    }
}