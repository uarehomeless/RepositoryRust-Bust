using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    public GameObject botPrefab;
    public float respawnTime = 3f;

    public void SpawnBot()
    {
        //Instantiate(botPrefab, transform.position, Quaternion.identity);
        Vector3 spawnPos = transform.position + Vector3.up * 10f;
        Instantiate(botPrefab, spawnPos, Quaternion.identity);
    }

    public void RespawnBot()
    {
        Debug.Log("Spawner position: " + transform.position);
        Invoke(nameof(SpawnBot), respawnTime);
    }
}