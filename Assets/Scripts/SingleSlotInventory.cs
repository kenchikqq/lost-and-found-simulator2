using UnityEngine;

public class SingleSlotInventory : MonoBehaviour
{
    public Item CurrentItem { get; private set; }

    public void AddItem(Item item)
    {
        CurrentItem = item;
    }

    public void RemoveItem()
    {
        CurrentItem = null;
    }

    public Item DropItem(Vector3 dropPosition)
    {
        if (CurrentItem != null)
        {
            CurrentItem.transform.position = dropPosition;
            CurrentItem.EnablePhysics(true);
            CurrentItem.gameObject.SetActive(true);

            Item dropped = CurrentItem;
            CurrentItem = null;
            return dropped;
        }
        return null;
    }
}
