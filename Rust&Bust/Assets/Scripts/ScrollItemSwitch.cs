using UnityEngine;

public class ScrollItemSwitch : MonoBehaviour
{
    public GameObject[] items;

    private int currentIndex = 0;

    public float scrollCooldown = 1f; // time between scrolls
    private float nextScrollTime = 0f;

    void Start()
    {
        UpdateItems();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // cooldown check
        if (Time.time < nextScrollTime) return;

        // REVERSED SCROLL DIRECTION
        if (scroll > 0f)
        {
            // scroll up = previous item
            currentIndex--;

            if (currentIndex < 0)
                currentIndex = items.Length - 1;

            UpdateItems();
            nextScrollTime = Time.time + scrollCooldown;
        }
        else if (scroll < 0f)
        {
            // scroll down = next item
            currentIndex = (currentIndex + 1) % items.Length;

            UpdateItems();
            nextScrollTime = Time.time + scrollCooldown;
        }
    }

    void UpdateItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(i == currentIndex);
        }
    }
}