using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform teleportTarget; // Where player will be teleported

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportTarget.position;
            Debug.Log("Player teleported!");
        }
    }
}