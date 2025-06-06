using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Camera playerCamera;
    public SingleSlotInventory inventory;
    public float pickupRange = 2f;

    void Update()
    {
        // Поднять предмет (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupRange))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    inventory.AddItem(item);
                    item.EnablePhysics(false); // Отключаем физику
                    item.gameObject.SetActive(false); // Делаем невидимым
                }
            }
        }

        // Выбросить предмет (Q)
        if (Input.GetKeyDown(KeyCode.Q) && inventory.CurrentItem != null)
        {
            Vector3 dropPos = playerCamera.transform.position + playerCamera.transform.forward * 1.5f;
            Item dropped = inventory.DropItem(dropPos);

            if (dropped != null)
            {
                dropped.EnablePhysics(true); // Включаем физику
                ItemThrow itemThrow = dropped.GetComponent<ItemThrow>();
                if (itemThrow != null)
                {
                    itemThrow.Throw(playerCamera.transform); // Выбросить предмет
                }
            }
        }
    }
}
