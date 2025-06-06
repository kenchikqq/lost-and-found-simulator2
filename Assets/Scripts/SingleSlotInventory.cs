using UnityEngine;
using UnityEngine.UI;
using TMPro;  // ��� ������ � TextMeshPro

public class SingleSlotInventory : MonoBehaviour
{
    // ������ �������� �������� � ���������
    public Item CurrentItem { get; private set; }

    // UI �������� ��� ����������� ������, ����� � �������� ��������
    [Header("UI")]
    public Image itemIcon; // ������ ��������
    public TextMeshProUGUI itemNameText; // ��� ��������
    public TextMeshProUGUI itemDescriptionText; // �������� ��������
    public GameObject inventoryPanel; // ������ ��������� (���������� ��� ��������)

    void Start()
    {
        // ������ ������ ��������� ��� ������
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    // ����� ��� ���������� �������� � ���������
    public void AddItem(Item item)
    {
        if (item == null) return;

        // ����������� ������� �������
        CurrentItem = item;

        // ���������� ������ ���������
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(true);
        }

        // ��������� ������, ���� ��� ���� � ��������
        if (itemIcon != null && item.itemIcon != null)
        {
            itemIcon.sprite = item.itemIcon;
        }

        // ��������� ��������� ���� ����� � �������� ��������
        if (itemNameText != null)
        {
            itemNameText.text = item.itemName;
        }
        else
        {
            Debug.LogError("itemNameText �� ��������!");
        }

        if (itemDescriptionText != null)
        {
            itemDescriptionText.text = item.itemDescription;
        }
        else
        {
            Debug.LogError("itemDescriptionText �� ��������!");
        }
    }

    // ����� ��� �������� �������� �� ���������
    public void RemoveItem()
    {
        CurrentItem = null;

        // ������� ������, ��� � ��������
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

        // �������� ������ ���������, ���� ������� �����
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    // ����� ��� ������� �������� �� ���������
    public Item DropItem(Vector3 dropPosition)
    {
        if (CurrentItem != null)
        {
            // ���������� ������� �� ������� �������
            CurrentItem.transform.position = dropPosition;

            // �������� ������ ��������
            CurrentItem.EnablePhysics(true);

            // ���������� ������� � ����
            CurrentItem.gameObject.SetActive(true);

            Item dropped = CurrentItem;
            CurrentItem = null;
            return dropped;
        }
        return null;
    }
}
