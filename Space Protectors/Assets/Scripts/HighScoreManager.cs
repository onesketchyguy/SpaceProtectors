using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public GameObject HighScoreTablePrefab;

    public static List<PlayerScore> scores = new List<PlayerScore>() { };

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
        if (HighScoreTablePrefab == null)
        {
            Debug.LogError("HighScoreTablePrefab not set!");
        }

        DestroyChildren();

        SetHighScores();
    }

    public void SetHighScores()
    {
        scores.Sort();

        scores.Reverse();

        foreach (var score in scores)
        {
            GameObject obj = Instantiate(HighScoreTablePrefab, transform) as GameObject;

            obj.name = $"ScoreTable[{transform.childCount}]";

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
}
