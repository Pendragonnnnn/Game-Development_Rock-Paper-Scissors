using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenController : MonoBehaviour
{
    [SerializeField] private GameObject startScreenPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private bool pauseTimeWhileInactive = true;

    private void Awake()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (startScreenPanel != null)
        {
            startScreenPanel.SetActive(true);
            if (pauseTimeWhileInactive)
            {
                Time.timeScale = 0f;
            }
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void StartGame()
    {
        if (startScreenPanel != null)
        {
            startScreenPanel.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (pauseTimeWhileInactive)
        {
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}