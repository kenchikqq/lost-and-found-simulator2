using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Для работы с TextMeshPro

public class SingleSlotInventory : MonoBehaviour
{
    // Объект текущего предмета в инвентаре
    public Item CurrentItem { get; private set; }

    // UI элементы для отображения иконки, имени и описания предмета
    [Header("UI")]
    public Image itemIcon; // Иконка предмета
    public TextMeshProUGUI itemNameText; // Имя предмета
    public TextMeshProUGUI itemDescriptionText; // Описание предмета
    public GameObject inventoryPanel; // Панель инвентаря (показывать или скрывать)

    void Start()
    {
        // Скрыть панель инвентаря при старте
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    // Метод для добавления предмета в инвентарь
    public void AddItem(Item item)
    {
        if (item == null) return;

        // Присваиваем текущий предмет
        CurrentItem = item;

        // Отображаем панель инвентаря
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(true);
        }

        // Обновляем иконку, если она есть у предмета
        if (itemIcon != null && item.itemIcon != null)
        {
            itemIcon.sprite = item.itemIcon;
        }

        // Обновляем текстовые поля имени и описания предмета
        if (itemNameText != null)
        {
            itemNameText.text = item.itemName;
        }
        else
        {
            Debug.LogError("itemNameText не привязан!");
        }

        if (itemDescriptionText != null)
        {
            itemDescriptionText.text = item.itemDescription;
        }
        else
        {
            Debug.LogError("itemDescriptionText не привязан!");
        }
    }

    // Метод для удаления предмета из инвентаря
    public void RemoveItem()
    {
        CurrentItem = null;

        // Очищаем иконку, имя и описание
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

        // Скрываем панель инвентаря, если предмет удалён
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    // Метод для выброса предмета из инвентаря
    public Item DropItem(Vector3 dropPosition)
    {
        if (CurrentItem != null)
        {
            // Перемещаем предмет на позицию выброса
            CurrentItem.transform.position = dropPosition;

            // Включаем физику предмета
            CurrentItem.EnablePhysics(true);

            // Отображаем предмет в мире
            CurrentItem.gameObject.SetActive(true);

            Item dropped = CurrentItem;
            CurrentItem = null;
            return dropped;
        }
        return null;
    }
}
