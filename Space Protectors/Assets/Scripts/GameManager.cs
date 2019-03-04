using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    internal static bool gameOver = true;

    public GameObject GameOverPanel;

    internal int lives = 1;

    public int StartingLives = 3;

    public static Vector3 ScreenMax, ScreenMid, ScreenMin;

    public static float ScreenPadding = 1;

    public GameObject[] enemyFormations;

    private GameObject enemyFormation;

    public GameObject Player;

    private void Awake()
    {
        float dist = Camera.main.transform.position.z;

        ScreenMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, dist));
        ScreenMid = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, dist));
        ScreenMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist));
    }

    private void Update()
    {
        if (enemyFormation == null && gameOver == false)
        {
            SpawnEnemies();
        }
        else 
        if (gameOver == true && enemyFormation != null)
        {
            Destroy(enemyFormation);
        }
    }

    public void StartGame()
    {
        gameOver = false;

        //Spawn enemies.
        SpawnEnemies();

        //Spawn player.
        SpawnPlayer();

        GameOverPanel.SetActive(false);

        lives = StartingLives;

        foreach (var item in FindObjectsOfType<ShieldManager>())
        {
            item.SpawnShield();
        }
    }

    private void SpawnEnemies()
    {
        enemyFormation = Instantiate(enemyFormations[Random.Range(0, enemyFormations.Length - 1)]) as GameObject;
    }

    private void SpawnPlayer()
    {
        Vector3 SpawnPoint = new Vector3(ScreenMid.x, ScreenMin.y + ScreenPadding);
        
        Instantiate(Player, SpawnPoint, Quaternion.identity);
    }

    public void KillPlayer()
    {
        lives -= 1;

        //Reset the level.
        if (lives <= 0)
        {
            gameOver = true;

            GameOverPanel.SetActive(true);
        }
        else
        {
            Invoke("SpawnPlayer", 1);
        }
    }

    public void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }
}
