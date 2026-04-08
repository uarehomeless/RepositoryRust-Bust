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

        // check cooldown
        if (Time.time < nextScrollTime) return;

        if (scroll > 0f)
        {
            currentIndex = (currentIndex + 1) % items.Length;
            UpdateItems();
            nextScrollTime = Time.time + scrollCooldown;
        }
        else if (scroll < 0f)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = items.Length - 1;

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