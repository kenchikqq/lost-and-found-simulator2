using UnityEngine;
using TMPro; // Не забудь подключить библиотеку для работы с TextMeshPro

public class InspectPanelUI : MonoBehaviour
{
    [Header("Панель осмотра")]
    public GameObject panel; // Панель для осмотра предмета
    public TextMeshProUGUI nameText; // Текст для имени предмета
    public TextMeshProUGUI descriptionText; // Текст для описания предмета

    // Этот метод будет вызываться для отображения панели с данными о предмете
    public void Show(string itemName, string itemDescription)
    {
        if (panel != null)
        {
            panel.SetActive(true); // Показываем панель
        }

        if (nameText != null)
        {
            nameText.text = itemName; // Устанавливаем имя предмета
        }
        else
        {
            Debug.LogError("nameText не привязан!");
        }

        if (descriptionText != null)
        {
            descriptionText.text = itemDescription; // Устанавливаем описание предмета
        }
        else
        {
            Debug.LogError("descriptionText не привязан!");
        }
    }

    // Этот метод будет вызываться для скрытия панели
    public void Hide()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Прячем панель
        }
        else
        {
            Debug.LogError("panel не привязан!");
        }
    }
}
