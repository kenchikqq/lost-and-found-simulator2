using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Camera playerCamera;
    public SingleSlotInventory inventory;
    public float pickupRange = 2f;

    void Update()
    {
        // Поднятие предмета (клавиша "E")
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupRange))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null && !inventory.CurrentItem) // Подбираем только если инвентарь пуст
                {
                    inventory.AddItem(item);  // Добавляем предмет в инвентарь
                    item.EnablePhysics(false);  // Отключаем физику при взятии
                    item.gameObject.SetActive(false);  // Делаем предмет невидимым
                }
            }
        }
    }
}
