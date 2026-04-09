using UnityEngine;

public class SimpleBot : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseSpeed = 2f;
    public float detectionRange = 15f;

    private Transform player;
    public float changeDirectionTime = 3f;

    private Vector3 moveDirection;
    private float timer;
    private BotSpawner spawner;
    private Vector3 spawnPosition;
    public GameObject hitEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PickNewDirection();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If player has scrap and is close → chase
        if (ScrapManager.Instance.scrap > 0 && distanceToPlayer < detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * chaseSpeed * Time.deltaTime;

            transform.forward = direction;
        }
        else
        {
            // Wander (your old logic)
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            timer += Time.deltaTime;

            if (timer >= changeDirectionTime)
            {
                PickNewDirection();
            }
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
    public void ForceRunAway(Vector3 safeZoneCenter)
    {
        Vector3 direction = (transform.position - safeZoneCenter).normalized;

        direction.y = 0;

        transform.position += direction * chaseSpeed * Time.deltaTime;
    }
}