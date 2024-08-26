using UnityEngine;
using UnityEngine.SceneManagement;

public class StopButtonController : MonoBehaviour
{
    
    public void OnStopButtonClicked()
    {
       
        SceneManager.LoadScene("StartScreen"); 
    }
}
