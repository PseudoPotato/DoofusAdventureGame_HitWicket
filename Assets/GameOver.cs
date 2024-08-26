using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5f) 
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
