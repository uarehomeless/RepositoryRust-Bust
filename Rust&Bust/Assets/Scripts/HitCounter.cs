using UnityEngine;

public class HitCounter : MonoBehaviour
{
    private int hits = 0;
    public float maxDistance = 2f; // adjust this in Inspector

    void OnMouseDown()
    {
        float distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        if (distance <= maxDistance)
        {
            hits++;

            if (hits >= 4)
            {
                Destroy(gameObject);
            }
        }
    }
}