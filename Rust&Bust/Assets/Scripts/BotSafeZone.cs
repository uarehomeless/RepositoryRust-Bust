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
}