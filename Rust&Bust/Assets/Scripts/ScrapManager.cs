using UnityEngine;
using TMPro;

public class ScrapManager : MonoBehaviour
{
    public static ScrapManager Instance;

    public int scrap = 0;
    public TMP_Text scrapText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        scrapText.text = "Scrap: 0";
    }

    public void AddScrap(int amount)
    {
        scrap += amount;

        if (scrap < 0)
            scrap = 0;

        scrapText.text = "Scrap: " + scrap;
    }
}