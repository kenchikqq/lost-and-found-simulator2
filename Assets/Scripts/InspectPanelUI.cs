using UnityEngine;
using TMPro;

public class InspectPanelUI : MonoBehaviour
{
    public GameObject panel; // сам InspectPanel
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public void Show(string itemName, string itemDescription)
    {
        panel.SetActive(true);          // Показываем панель
        nameText.text = itemName;       // Имя предмета
        descriptionText.text = itemDescription; // Описание
    }

    public void Hide()
    {
        panel.SetActive(false);         // Скрываем панель
    }
}
