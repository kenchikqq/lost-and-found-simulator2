using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    public string itemName = "Имя предмета";
    public string itemDescription = "Описание предмета";
    public Sprite icon;

    [HideInInspector] public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();
    }

    public void EnablePhysics(bool enable)
    {
        if (rb == null) return;

        rb.isKinematic = !enable;
        rb.useGravity = enable;
    }
}
