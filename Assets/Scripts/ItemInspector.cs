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
    private bool isInspecting = false;

    void Start()
    {
        // Скрываем панель при запуске
        if (inspectPanel != null)
        {
            inspectPanel.Hide();
            Debug.Log("Панель осмотра скрыта при старте");
        }
    }

    void Update()
    {
        // Запуск осмотра
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventory != null && inventory.CurrentItem != null)
            {
                InspectItem(inventory.CurrentItem);
                isInspecting = true;
                Debug.Log("Нажата клавиша 1 - запускаем осмотр");
            }
            else
            {
                Debug.Log("Нет предмета для осмотра");
            }
        }

        // Выход из осмотра
        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Нажата Escape - выход из осмотра");
            ExitInspection();
        }

        // Вращение предмета мышкой
        if (isInspecting && Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
            float rotY = -Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

            if (inspectedItem != null)
            {
                inspectedItem.transform.Rotate(Vector3.up, rotX, Space.World);
                inspectedItem.transform.Rotate(Vector3.right, rotY, Space.World);
            }
        }
    }

    /// <summary>
    /// Начало осмотра предмета
    /// </summary>
    public void InspectItem(Item item)
    {
        inspectedItem = item;

        // Перемещаем предмет
        inspectedItem.transform.SetParent(inspectionPoint);
        inspectedItem.transform.localPosition = Vector3.zero;
        inspectedItem.transform.localRotation = Quaternion.identity;

        // Отключаем физику
        inspectedItem.EnablePhysics(false);
        inspectedItem.gameObject.SetActive(true);

        // Показываем UI
        if (inspectPanel != null)
        {
            string desc = string.IsNullOrEmpty(item.itemDescription) ? "Описание отсутствует." : item.itemDescription;
            inspectPanel.Show(item.itemName, desc);
        }

        Debug.Log("Начат осмотр предмета: " + item.itemName);
    }

    /// <summary>
    /// Завершение осмотра предмета
    /// </summary>
    public void ExitInspection()
    {
        if (inspectedItem != null)
        {
            inspectedItem.gameObject.SetActive(false);
            inspectedItem.transform.SetParent(null);
            inspectedItem = null;
        }

        if (inspectPanel != null)
        {
            inspectPanel.Hide();
        }

        isInspecting = false;
        Debug.Log("Осмотр завершён");
    }
}
