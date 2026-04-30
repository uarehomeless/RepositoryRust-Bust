using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 🚫 Ignore other arrows
        if (collision.collider.CompareTag("Arrow"))
        {
            return;
        }

        // Check if we hit a bot
        SimpleBot bot = collision.collider.GetComponentInParent<SimpleBot>();

        if (bot != null)
        {
            Debug.Log("Arrow hit bot: " + bot.name);

            bot.TeleportToSpawn();

            Destroy(gameObject);
        }
        else
        {
            // 🧱 Hit wall or anything else → destroy
            Destroy(gameObject);
        }
    }
}