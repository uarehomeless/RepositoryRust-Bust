using UnityEngine;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    public TextMeshProUGUI slotText;

    int[] bets = {1, 5, 10, 20, 50, 100, 250, 500, 1000 };
    private int currentBetIndex = 0;

    private bool playerInRange = false;


    void Update()
    {
        if (!playerInRange) return;

        // Change bet
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentBetIndex++;
            if (currentBetIndex >= bets.Length)
                currentBetIndex = 0;

            UpdateUI();
        }

        // Spin
        if (Input.GetKeyDown(KeyCode.E))
        {
            Spin();
        }
    }

    void Spin()
    {
        int bet = bets[currentBetIndex];

        if (ScrapManager.Instance.scrap < bet)
        {
            slotText.text = "Not enough scrap!";
            return;
        }

        // Remove bet
        ScrapManager.Instance.AddScrap(-bet);

        int roll = Random.Range(0, 100); // 0–99

        if (roll < 70) // 70% lose
        {
            slotText.text = "You lost! (-" + bet + ")";
        }
        else if (roll < 95) // 25% win x2
        {
            int win = bet * 2;
            ScrapManager.Instance.AddScrap(win);
            slotText.text = "You won x2! (+" + win + ")";
        }
        else // 5% jackpot
        {
            int win = bet * 10;
            ScrapManager.Instance.AddScrap(win);
            slotText.text = "JACKPOT x10!!! (+" + win + ")";
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        slotText.text = "Current Bet: " + bets[currentBetIndex] +
        "\nQ = Change Bet\nE = Spin";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            slotText.gameObject.SetActive(true);
            UpdateUI();
            Debug.Log("Player entered slot machine range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            slotText.gameObject.SetActive(false);
            Debug.Log("Player left slot machine range");
        }
    }
}