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
                int scrapAmount = GetRandomScrap();
                ScrapManager.Instance.AddScrap(scrapAmount);

                gameObject.SetActive(false);
                Invoke(nameof(Respawn), 20f);
            }
        }
    }

    int GetRandomScrap()
    {
        float rand = Random.Range(0f, 100f);

        if (rand <= 60f) // 60% chance
        {
            return Random.Range(1, 26); // 1–25
        }
        else if (rand <= 95f) // 35% chance (60 + 35)
        {
            return Random.Range(50, 151); // 50–150
        }
        else if (rand <= 99f) // 4% chance (95 + 4)
        {
            return Random.Range(250, 1001); // 250–1000
        }
        else // 1% chance (100 - 99)
        {
            return Random.Range(2500, 10001); // 2500–10000
        }
    }

    void Respawn()
    {
        hits = 0;
        gameObject.SetActive(true);
    }
}