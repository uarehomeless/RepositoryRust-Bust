using UnityEngine;

public class ScrollItemSwitch : MonoBehaviour
{
    public GameObject[] items;

    private int currentIndex = 0;

    void Start()
    {
        UpdateItems();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            currentIndex = (currentIndex + 1) % items.Length;
            UpdateItems();
        }
        else if (scroll < 0f)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = items.Length - 1;

            UpdateItems();
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