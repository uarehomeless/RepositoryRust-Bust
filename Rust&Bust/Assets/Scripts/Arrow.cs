using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Try to find a bot on what we hit
        SimpleBot bot = collision.collider.GetComponentInParent<SimpleBot>();

        if (bot != null)
        {
            Debug.Log("Arrow hit bot: " + bot.name);
            bot.TeleportToSpawn();
        }

        // Destroy arrow on impact
        Destroy(gameObject);
    }
}