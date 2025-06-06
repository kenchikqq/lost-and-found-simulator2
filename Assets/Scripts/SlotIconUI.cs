using UnityEngine;
using UnityEngine.UI;

public class SlotIconUI : MonoBehaviour
{
    public SingleSlotInventory inventory; // �������� ���� ������ � SingleSlotInventory
    public Image iconImage;               // �������� ���� UI Image (SlotIcon)

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
