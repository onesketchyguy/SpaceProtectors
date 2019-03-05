using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public GameObject HighScoreTablePrefab;

    public static List<PlayerScore> scores = new List<PlayerScore>() { };

    private int maxScores = 20;

    [System.Serializable]
    public class PlayerScore : IComparable<PlayerScore>
    {
        public string name;

        public int score;

        public int CompareTo(PlayerScore other)
        {
            if (other.score > score)
            {
                return -1;
            }
            else if (other.score == score)
            {
                return 0;
            }

            return 1;
        }
    }

    private void OnEnable()
    {
        LoadScores();

        if (HighScoreTablePrefab == null)
        {
            Debug.LogError("HighScoreTablePrefab not set!");
        }

        DestroyChildren();

        SetHighScores();

        SaveScores();
    }

    public void SetHighScores()
    {
        scores.Sort();

        scores.Reverse();

        for (int i = 0; i < scores.Count; i++)
        {
            if (i >= maxScores) break;

            PlayerScore score = scores[i];
            GameObject obj = Instantiate(HighScoreTablePrefab, transform) as GameObject;

            obj.name = $"ScoreTable[{i}]";

            Text textObj = obj.GetComponent<Text>();

            if (textObj)
            {
                textObj.text = $"{score.name} : {score.score}";
            }
        }
    }

    public void DestroyChildren()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
        {
            if (child == transform) continue;

            Destroy(child.gameObject);
        }
    }

    private void SaveScores()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            PlayerScore score = (PlayerScore)scores[i];

            PlayerPrefs.SetString($"PLAYERNAME{i}", score.name);

            PlayerPrefs.SetInt($"PLAYERSCORE{i}", score.score);
        }
    }

    private void LoadScores()
    {
        for (int i = 0; i < maxScores; i++)
        {
            string name = PlayerPrefs.GetString($"PLAYERNAME{i}");

            int value = PlayerPrefs.GetInt($"PLAYERSCORE{i}");

            if (name != string.Empty)
            {
                PlayerScore newScore = new PlayerScore
                {
                    name = name,
                    score = value
                };

                scores.Add(newScore);
            }
        }
    }
}
