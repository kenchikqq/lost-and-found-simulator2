using UnityEngine;
using UnityEngine.UI;

public class SingleSlotInventory : MonoBehaviour
{
    public Item CurrentItem { get; private set; }

    [Header("UI")]
    public Image itemIcon;
    public Text itemNameText;
    public Text itemDescriptionText;
    public GameObject inventoryPanel;

    void Start()
    {
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void AddItem(Item item)
    {
        CurrentItem = item;
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(true);
        }

        if (itemIcon != null && item.itemIcon != null)
        {
            itemIcon.sprite = item.itemIcon;
        }

        if (itemNameText != null)
        {
            itemNameText.text = item.itemName;
        }

        if (itemDescriptionText != null)
        {
            itemDescriptionText.text = item.itemDescription;
        }
    }

    public void RemoveItem()
    {
        CurrentItem = null;

        if (itemIcon != null)
        {
            itemIcon.sprite = null;
        }

        if (itemNameText != null)
        {
            itemNameText.text = "";
        }

        if (itemDescriptionText != null)
        {
            itemDescriptionText.text = "";
        }

        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    public Item DropItem(Vector3 dropPosition)
    {
        if (CurrentItem != null)
        {
            CurrentItem.transform.position = dropPosition;
            CurrentItem.EnablePhysics(true);
            CurrentItem.gameObject.SetActive(true);

            Item dropped = CurrentItem;
            CurrentItem = null;
            return dropped;
        }
        return null;
    }
}
