using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreenNew; 

    void Start()
    {
        if (gameOverScreenNew != null)
        {
            gameOverScreenNew.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverScreenNew reference is not assigned!");
        }
    }

    public void TriggerGameOver()
    {
        if (gameOverScreenNew != null)
        {
            gameOverScreenNew.SetActive(true); 
            Time.timeScale = 0f; 
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
