using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    public GameObject botPrefab;
    public float respawnTime = 3f;

    public void SpawnBot()
    {
        Instantiate(botPrefab, transform.position, Quaternion.identity);
    }

    public void RespawnBot()
    {
        Invoke(nameof(SpawnBot), respawnTime);
    }
}