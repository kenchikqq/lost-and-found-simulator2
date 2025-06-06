using UnityEngine;

public class ItemInspector : MonoBehaviour
{
    [Header("Позиция для осмотра")]
    public Transform inspectionPoint;

    [Header("Инвентарь игрока")]
    public SingleSlotInventory inventory;

    [Header("UI панель осмотра")]
    public InspectPanelUI inspectPanel;

    private Item inspectedItem;
    private bool isInspecting = false;  // Является ли предмет в осмотре
    private bool hasItemBeenThrown = false;  // Флаг для проверки выброшен ли предмет
    private bool canInspect = false;  // Флаг, разрешающий осмотр

    void Start()
    {
        if (inspectPanel != null)
        {
            inspectPanel.Hide(); // Скрыть панель осмотра при старте
        }
    }

    void Update()
    {
        // Проверка на клавишу "1" для осмотра предмета
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.CurrentItem != null)
        {
            // Если можно осматривать, то запускаем осмотр
            if (!isInspecting && !hasItemBeenThrown)
            {
                InspectItem(inventory.CurrentItem);  // Запуск осмотра предмета
                isInspecting = true;
                inspectPanel.Show(inventory.CurrentItem.itemName, inventory.CurrentItem.itemDescription);  // Показываем описание
            }
            else if (isInspecting)  // Если уже осматриваем предмет, скрываем описание
            {
                ExitInspection();
            }
        }

        // Выход из осмотра при нажатии "Escape"
        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInspection();  // Выход из осмотра
        }

        // Выброс предмета при нажатии "Q"
        if (Input.GetKeyDown(KeyCode.Q) && inventory != null && inventory.CurrentItem != null && !hasItemBeenThrown)
        {
            hasItemBeenThrown = true;
            inspectPanel.Hide(); // Прячем панель осмотра при выбросе

            // Вычисление позиции выброса
            Vector3 dropPos = Camera.main.transform.position + Camera.main.transform.forward * 2f + Vector3.down * 0.3f;
            Item dropped = inventory.DropItem(dropPos);  // Выбрасываем предмет из инвентаря

            if (dropped != null)
            {
                // Включаем физику предмета при выбросе
                ItemPhysicsController itemPhysicsController = dropped.GetComponent<ItemPhysicsController>();
                if (itemPhysicsController != null)
                {
                    itemPhysicsController.DetachFromParent();  // Отвязываем от родителя
                    itemPhysicsController.EnablePhysics();  // Включаем физику
                    itemPhysicsController.SetDropPosition(dropPos);  // Устанавливаем правильную позицию для выброса
                }

                // Используем ItemThrow для реального выброса предмета
                ItemThrow itemThrow = dropped.GetComponent<ItemThrow>();
                if (itemThrow != null)
                {
                    itemThrow.Throw(Camera.main.transform);  // Выбрасываем предмет с силой от камеры
                }
            }
        }

        // Установим флаг "canInspect" на true, если предмет в инвентаре
        if (inventory.CurrentItem != null && !hasItemBeenThrown)
        {
            canInspect = true;  // Разрешаем осмотр
        }
    }

    // Метод для осмотра предмета
    public void InspectItem(Item item)
    {
        if (item == null) return;

        inspectedItem = item;
        inspectedItem.EnablePhysics(false); // Отключаем физику при осмотре
        item.transform.SetParent(inspectionPoint);  // Привязываем предмет к точке осмотра
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.gameObject.SetActive(true);  // Делаем предмет видимым

        if (inspectPanel != null)
        {
            string desc = string.IsNullOrEmpty(item.itemDescription) ? "Описание отсутствует." : item.itemDescription;
            inspectPanel.Show(item.itemName, desc);  // Показать имя и описание предмета
        }
    }

    // Метод для выхода из осмотра
    public void ExitInspection()
    {
        // Если предмет был выброшен, не скрываем панель осмотра
        if (!hasItemBeenThrown)
        {
            if (inspectedItem != null)
            {
                inspectedItem.transform.SetParent(null);  // Отвязываем предмет от родителя
                Vector3 dropPosition = Camera.main.transform.position + Camera.main.transform.forward * 2f + Vector3.down * 0.3f;
                inspectedItem.transform.position = dropPosition;  // Перемещаем предмет в нужное место после осмотра
                inspectedItem.EnablePhysics(true);  // Включаем физику
                inspectedItem = null;  // Сбрасываем ссылку на осматриваемый предмет
            }

            if (inspectPanel != null)
            {
                inspectPanel.Hide();  // Прячем панель осмотра
            }

            isInspecting = false;  // Завершаем осмотр
            canInspect = false;  // Запрещаем новый осмотр до того, как предмет будет снова поднят
        }
    }
}
