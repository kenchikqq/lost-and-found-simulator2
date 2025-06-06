using UnityEngine;


public class ItemInspector : MonoBehaviour
{

    [Header("������� ��� �������")]
    public Transform inspectionPoint;

    [Header("��������� ������")]
    public SingleSlotInventory inventory;

    [Header("UI ������ �������")]
    public InspectPanelUI inspectPanel;

    private Item inspectedItem;
    private bool isInspecting = false;

    void Start()
    {
        // �������� ������ ��� �������
        if (inspectPanel != null)
        {
            inspectPanel.Hide();
            Debug.Log("������ ������� ������ ��� ������");
        }
    }

    void Update()
    {
        // ������ �������
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventory != null && inventory.CurrentItem != null)
            {
                InspectItem(inventory.CurrentItem);
                isInspecting = true;
                Debug.Log("������ ������� 1 - ��������� ������");
            }
            else
            {
                Debug.Log("��� �������� ��� �������");
            }
        }

        // ����� �� �������
        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("������ Escape - ����� �� �������");
            ExitInspection();
        }

        // �������� �������� ������
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
    /// ������ ������� ��������
    /// </summary>
    public void InspectItem(Item item)
    {
        inspectedItem = item;

        // ���������� �������
        inspectedItem.transform.SetParent(inspectionPoint);
        inspectedItem.transform.localPosition = Vector3.zero;
        inspectedItem.transform.localRotation = Quaternion.identity;

        // ��������� ������
        inspectedItem.EnablePhysics(false);
        inspectedItem.gameObject.SetActive(true);

        // ���������� UI
        if (inspectPanel != null)
        {
            string desc = string.IsNullOrEmpty(item.itemDescription) ? "�������� �����������." : item.itemDescription;
            inspectPanel.Show(item.itemName, desc);
        }

        Debug.Log("����� ������ ��������: " + item.itemName);
    }

    /// <summary>
    /// ���������� ������� ��������
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
        Debug.Log("������ ��������");
    }
}
