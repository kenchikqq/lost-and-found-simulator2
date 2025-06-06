using UnityEngine;
using UnityEngine.UI;

public class SlotIconUI : MonoBehaviour
{
    public SingleSlotInventory inventory; // ���������
    public Image iconImage;               // ������

    void Update()
    {
        if (inventory != null && inventory.CurrentItem != null && inventory.CurrentItem.itemIcon != null)
        {
            iconImage.enabled = true;
            iconImage.sprite = inventory.CurrentItem.itemIcon; // ����������� ������
        }
        else
        {
            iconImage.enabled = false;
        }
    }
}
