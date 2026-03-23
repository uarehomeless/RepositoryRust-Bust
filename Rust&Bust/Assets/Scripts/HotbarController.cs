using UnityEngine;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    public Image[] slotImages;
    public ItemData[] items;

    public Transform handTransform; // where item appears

    public Color selectedColor = Color.white;
    public Color normalColor = Color.gray;

    private int selectedIndex = 0;
    private GameObject currentItemObject;

    void Start()
    {
        UpdateHotbar();
        UpdateHeldItem();
    }

    void Update()
    {
        // Number keys
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSlot(4);

        // Scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            selectedIndex = (selectedIndex + 1) % items.Length;
            UpdateHotbar();
            UpdateHeldItem();
        }
        else if (scroll < 0f)
        {
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = items.Length - 1;

            UpdateHotbar();
            UpdateHeldItem();
        }
    }

    void SelectSlot(int index)
    {
        selectedIndex = index;
        UpdateHotbar();
        UpdateHeldItem();
    }

    void UpdateHotbar()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            // Set icon
            if (items[i] != null)
            {
                slotImages[i].sprite = items[i].icon;
                slotImages[i].color = (i == selectedIndex) ? selectedColor : normalColor;
            }
        }
    }

    void UpdateHeldItem()
    {
        // Remove old item
        if (currentItemObject != null)
        {
            Destroy(currentItemObject);
        }

        // Spawn new item
        ItemData item = items[selectedIndex];

        if (item != null && item.prefab != null)
        {
            currentItemObject = Instantiate(item.prefab, handTransform);
            currentItemObject.transform.localPosition = Vector3.zero;
            currentItemObject.transform.localRotation = Quaternion.identity;
        }
    }
}