using UnityEngine;
using TMPro; // �� ������ ���������� ���������� ��� ������ � TextMeshPro

public class InspectPanelUI : MonoBehaviour
{
    [Header("������ �������")]
    public GameObject panel; // ������ ��� ������� ��������
    public TextMeshProUGUI nameText; // ����� ��� ����� ��������
    public TextMeshProUGUI descriptionText; // ����� ��� �������� ��������

    // ���� ����� ����� ���������� ��� ����������� ������ � ������� � ��������
    public void Show(string itemName, string itemDescription)
    {
        if (panel != null)
        {
            panel.SetActive(true); // ���������� ������
        }

        if (nameText != null)
        {
            nameText.text = itemName; // ������������� ��� ��������
        }
        else
        {
            Debug.LogError("nameText �� ��������!");
        }

        if (descriptionText != null)
        {
            descriptionText.text = itemDescription; // ������������� �������� ��������
        }
        else
        {
            Debug.LogError("descriptionText �� ��������!");
        }
    }

    // ���� ����� ����� ���������� ��� ������� ������
    public void Hide()
    {
        if (panel != null)
        {
            panel.SetActive(false); // ������ ������
        }
        else
        {
            Debug.LogError("panel �� ��������!");
        }
    }
}
