using UnityEngine;

public class ItemPhysics : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    public void EnablePhysics(bool enable)
    {
        if (rb == null) return;

        rb.isKinematic = !enable; // ���� ������ ��������, �� ���������� ���������
        rb.useGravity = enable;   // �������� ����������

        if (!enable)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void DetachFromParent()
    {
        // ���������� ������ �� ��������, ����� �� �� �������� �� �������
        transform.SetParent(null);
    }
}
