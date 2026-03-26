using UnityEngine;

public class SimpleBot : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionTime = 3f;

    private Vector3 moveDirection;
    private float timer;
    private BotSpawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<BotSpawner>();
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
        Debug.Log("Bot destroyed!");

        spawner.RespawnBot();
        Destroy(gameObject);
    }
}