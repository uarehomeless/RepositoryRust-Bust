using UnityEngine;

public class HitCounter : MonoBehaviour
{
    private int hits = 0;
    public float maxDistance = 2f;

    void OnMouseDown()
    {
        float distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        if (distance <= maxDistance)
        {
            hits++;

            if (hits >= 4)
            {
                gameObject.SetActive(false);
                Invoke(nameof(Respawn), 80f);
            }
        }
    }

    void Respawn()
    {
        hits = 0;
        gameObject.SetActive(true);
    }
}