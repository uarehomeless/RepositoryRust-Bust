using UnityEngine;

public class SimpleHotbar : MonoBehaviour
{
    public GameObject[] items;

    private int selectedIndex = 0;

    void Start()
    {
        SelectItem(0);
    }

    void Update()
    {
        // Number keys
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectItem(4);

        // Scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            selectedIndex = (selectedIndex + 1) % items.Length;
            SelectItem(selectedIndex);
        }
        else if (scroll < 0f)
        {
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = items.Length - 1;

            SelectItem(selectedIndex);
        }
    }

    void SelectItem(int index)
    {
        selectedIndex = index;

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(i == selectedIndex);
        }
    }
}