using UnityEngine;
using UnityEngine.UI;

public class SlotIconUI : MonoBehaviour
{
    public SingleSlotInventory inventory; // Перетащи сюда объект с SingleSlotInventory
    public Image iconImage;               // Перетащи сюда UI Image (SlotIcon)

    void Update()
    {
        if (inventory.CurrentItem != null && inventory.CurrentItem.icon != null)
        {
            iconImage.enabled = true;
            iconImage.sprite = inventory.CurrentItem.icon;
        }
        else
        {
            iconImage.enabled = false;
        }
    }
}
