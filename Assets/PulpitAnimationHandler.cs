using System.Collections;
using UnityEngine;

public class PulpitAnimationController : MonoBehaviour
{
    private Animator animator;
    public float spawnAnimationDelay = 1f; 
    public float pulpitLifetime = 4f; 

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
            return;
        }

        
        StartCoroutine(PlaySpawnAnimation());
    }

    IEnumerator PlaySpawnAnimation()
    {
        animator.SetBool("IsSpawning", true);
        yield return new WaitForSeconds(1f); 
        animator.SetBool("IsSpawning", false);

        
        yield return new WaitForSeconds(pulpitLifetime);

        
        animator.SetBool("IsDespawning", true);

        
        yield return new WaitForSeconds(1f); 

        Destroy(gameObject);
    }
}
