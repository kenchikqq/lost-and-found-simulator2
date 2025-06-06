using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Camera playerCamera;
    public float pickupRange = 2f;
    public float dropForwardDistance = 1.5f;
    public SingleSlotInventory inventory;

    void Update()
    {
        // Поднять предмет (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    inventory.AddItem(item);
                    item.EnablePhysics(false);
                    item.gameObject.SetActive(false);
                    Debug.Log("Предмет поднят: " + item.itemName);
                }
            }
        }

        // Выбросить предмет (Q)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventory.CurrentItem != null)
            {
                Vector3 dropPos = playerCamera.transform.position + playerCamera.transform.forward * dropForwardDistance;
                Item dropped = inventory.DropItem(dropPos);

                if (dropped != null)
                {
                    dropped.EnablePhysics(true);

                    // Немного отталкиваем предмет вперёд
                    if (dropped.rb != null)
                    {
                        dropped.rb.linearVelocity = playerCamera.transform.forward * 2f;
                        dropped.rb.angularVelocity = Random.insideUnitSphere * 2f;
                    }

                    Debug.Log("Предмет выброшен: " + dropped.itemName);
                }
            }
        }
    }
}
