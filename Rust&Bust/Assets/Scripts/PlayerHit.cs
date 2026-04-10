using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float hitRange = 2f; // How close player must be
    public Camera playerCamera;
    public Animator weaponAnimator;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            if (weaponAnimator != null)
            {
                weaponAnimator.SetTrigger("Hit");
            }

            TryHit();
        }
    }

    void TryHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, hitRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            SimpleBot bot = hit.collider.GetComponent<SimpleBot>();

            if (bot != null)
            {
                bot.TeleportToSpawn();
            }
        }
    }
}