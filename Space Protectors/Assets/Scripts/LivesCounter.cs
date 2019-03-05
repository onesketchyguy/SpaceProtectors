using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    private List<GameObject> lives = new List<GameObject>() { };

    public GameObject life;

    public void UpdateLivesCount(int playerLives)
    {
        while (lives.Count < playerLives)
        {
            GameObject l = Instantiate(life, transform) as GameObject;

            lives.Add(l);
        }

        while (lives.Count > playerLives)
        {
            GameObject l = lives[0];

            Destroy(l);

            lives.Remove(l);
        }
    }
}
