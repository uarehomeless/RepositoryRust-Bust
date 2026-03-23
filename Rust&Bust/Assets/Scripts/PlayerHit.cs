using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float hitRange = 2f; // How close player must be
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            TryHit();
        }
    }

    void TryHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, hitRange))
        {
            if (hit.collider.CompareTag("Hittable"))
            {
                Debug.Log("You hit a hittable object: " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("Missed");
        }
    }
}