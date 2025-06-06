using UnityEngine;
using TMPro;

public class InspectPanelUI : MonoBehaviour
{
    public GameObject panel; // ��� InspectPanel
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public void Show(string itemName, string itemDescription)
    {
        panel.SetActive(true);          // ���������� ������
        nameText.text = itemName;       // ��� ��������
        descriptionText.text = itemDescription; // ��������
    }

    public void Hide()
    {
        panel.SetActive(false);         // �������� ������
    }
}
