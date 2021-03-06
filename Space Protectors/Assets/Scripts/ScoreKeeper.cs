﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text ScoreTextObject;

    public int score { get; private set; }

    private void OnEnable()
    {
        ScoreTextObject.text = $"{score}";
    }

    public void AddScore(int scoreToAdd)
    {
        if (GameManager.gameOver == true)
        {
            Debug.Log("Unable to add score, the game is over!");
            return;
        }

        score += scoreToAdd;

        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (ScoreTextObject != null)
        {
            ScoreTextObject.text = $"{score}";
        }
    }
}
