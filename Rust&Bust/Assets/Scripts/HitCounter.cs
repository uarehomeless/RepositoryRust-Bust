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
                // Give random scrap (1–5)
                int scrapAmount = Random.Range(1, 6);
                ScrapManager.Instance.AddScrap(scrapAmount);

                gameObject.SetActive(false);
                Invoke(nameof(Respawn), 20f);
            }
        }
    }

    void Respawn()
    {
        hits = 0;
        gameObject.SetActive(true);
    }
}