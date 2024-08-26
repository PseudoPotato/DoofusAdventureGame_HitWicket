using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject pulpit1;
    public GameObject pulpit2;

    private float minPulpitDestroyTime;
    private float maxPulpitDestroyTime;
    private float pulpitSpawnTime;

    private string configUrl = "https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json";  // Replace with your JSON URL

    void Start()
    {
        StartCoroutine(LoadConfig()); 
    }

    IEnumerator LoadConfig()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(configUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
               
                string json = www.downloadHandler.text;
                GameConfig config = JsonUtility.FromJson<GameConfig>(json);

               
                minPulpitDestroyTime = config.pulpit_data.min_pulpit_destroy_time;
                maxPulpitDestroyTime = config.pulpit_data.max_pulpit_destroy_time;
                pulpitSpawnTime = config.pulpit_data.pulpit_spawn_time;

                
                Destroy(pulpit1, maxPulpitDestroyTime);

                
                StartCoroutine(DelayPulpit());
            }
            else
            {
                Debug.LogError("Failed to load config from URL: " + www.error);
            }
        }
    }

    IEnumerator DelayPulpit()
    {
        yield return new WaitForSeconds(pulpitSpawnTime);  
        SpawnPulpit();
    }

    void SpawnPulpit()
    {
        Vector3 pulpit1Position = pulpit1.transform.position;
        Vector3[] adjacentOffsets = new Vector3[]
        {
            new Vector3(9, 0, 0),  // Right
            new Vector3(-9, 0, 0),  // Left
            new Vector3(0, 0, 9),  // Forward
            new Vector3(0, 0, -9)  // Backward
        };
        int r = Random.Range(0, adjacentOffsets.Length);

        Vector3 pulpit2Position = pulpit1Position + adjacentOffsets[r];

        
        GameObject newPulpit = Instantiate(pulpit2, pulpit2Position, Quaternion.identity);

        
        newPulpit.AddComponent<PulpitAnimationController>();
    }
}
