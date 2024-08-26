using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            
            ScoreCount.instance.IncreaseScore(1);
        }
    }
}