using UnityEngine;
using UnityEngine.UI;

public class SlotIconUI : MonoBehaviour
{
    public SingleSlotInventory inventory; // Инвентарь
    public Image iconImage;               // Иконка

    void Update()
    {
        if (inventory != null && inventory.CurrentItem != null && inventory.CurrentItem.itemIcon != null)
        {
            iconImage.enabled = true;
            iconImage.sprite = inventory.CurrentItem.itemIcon; // Присваиваем иконку
        }
        else
        {
            iconImage.enabled = false;
        }
    }
}
