using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private GameObject MenuPanel;

    private void Start()
    {
        MenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        gameManager.StartGame();

        MenuPanel.SetActive(false);
    }

    public void QuitGame()
    {
        MenuPanel.SetActive(false);

        Application.Quit();
    }

    public void OpenMainMenu()
    {
        MenuPanel.SetActive(true);

        gameManager.GameOverPanel.SetActive(false);
    }
}
