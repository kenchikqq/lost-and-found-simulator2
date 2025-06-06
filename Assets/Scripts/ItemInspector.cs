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
    private bool hasItemBeenThrown = false; // Проверка выброса предмета

    void Start()
    {
        if (inspectPanel != null)
        {
            inspectPanel.Hide();
        }
    }

    void Update()
    {
        // Запуск осмотра (клавиша "1")
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventory.CurrentItem != null)
            {
                InspectItem(inventory.CurrentItem);
                isInspecting = true;
            }
        }

        // Выход из осмотра (Escape)
        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInspection();
        }

        // Вращение предмета при осмотре
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

        // Выброс предмета (клавиша Q)
        if (Input.GetKeyDown(KeyCode.Q) && inventory.CurrentItem != null && !hasItemBeenThrown)
        {
            hasItemBeenThrown = true;
            inspectPanel.Hide();
            Vector3 dropPos = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
            Item dropped = inventory.DropItem(dropPos);

            if (dropped != null)
            {
                dropped.EnablePhysics(true);
                Rigidbody rb = dropped.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(Camera.main.transform.forward * 2f, ForceMode.Impulse);
                }
            }
        }
    }

    public void InspectItem(Item item)
    {
        if (item == null) return;

        inspectedItem = item;
        inspectedItem.EnablePhysics(false);
        item.transform.SetParent(inspectionPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.gameObject.SetActive(true);

        if (inspectPanel != null)
        {
            string desc = string.IsNullOrEmpty(item.itemDescription) ? "Описание отсутствует." : item.itemDescription;
            inspectPanel.Show(item.itemName, desc);
        }
    }

    public void ExitInspection()
    {
        if (inspectedItem != null)
        {
            inspectedItem.transform.SetParent(null);
            inspectedItem.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f + Vector3.down * 0.3f;
            inspectedItem.EnablePhysics(true);
            inspectedItem = null;
        }

        if (inspectPanel != null)
        {
            inspectPanel.Hide();
        }

        isInspecting = false;
        hasItemBeenThrown = false;
    }
}
