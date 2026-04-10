using UnityEngine;

public class BotSafeZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        SimpleBot bot = other.GetComponent<SimpleBot>();

        if (bot != null)
        {
            bot.ForceRunAway(transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(100); // restores to max
            }
        }
    }
}