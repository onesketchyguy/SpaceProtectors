using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject NameInput, HighScore;

    private void OnEnable()
    {
        NameInput.SetActive(true);

        HighScore.SetActive(false);
    }

    public void NameInputed(string nameInput)
    {
        NameInput.SetActive(false);

        //Get score from score keeper.

        int scoreRetrieved = FindObjectOfType<ScoreKeeper>().score;

        //Add score to score board.

        HighScoreManager.PlayerScore playerScore = new HighScoreManager.PlayerScore
        {
            name = nameInput,
            score = scoreRetrieved
        };

        HighScoreManager.scores.Add(playerScore);

        HighScore.SetActive(true);
    }
}
