using UnityEngine;

public class SimpleBot : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionTime = 3f;

    private Vector3 moveDirection;
    private float timer;
    private BotSpawner spawner;
    private Vector3 spawnPosition;
    public GameObject hitEffect;

    void Start()
    {
        spawner = FindObjectOfType<BotSpawner>();
        spawnPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            PickNewDirection();
        }
    }

    void PickNewDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        moveDirection = new Vector3(x, 0, z).normalized;
        timer = 0f;
    }
    public void OnHit()
    {
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
        spawner.RespawnBot();
        Destroy(gameObject);
    }
    public void TeleportToSpawn()
    {
        transform.position = spawnPosition;
    }
}