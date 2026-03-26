using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportTarget.position;
        }

        SimpleBot bot = other.GetComponent<SimpleBot>();

        if (bot != null)
        {
            bot.TeleportToSpawn();
        }
    }
}