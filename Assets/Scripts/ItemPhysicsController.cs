using UnityEngine;

public class ItemPhysicsController : MonoBehaviour
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>(); // ���� Rigidbody �����������, ��������� ���
        }
        rb.isKinematic = true; // �� ��������� ������ ���������
        rb.useGravity = false; // �� ��������� ��������� ����������
    }

    // �������� ������ ��� �������
    public void EnablePhysics()
    {
        rb.isKinematic = false;  // ��������� ����������
        rb.useGravity = true;    // �������� ����������
    }

    // ��������� ������ (��� ������� ��������)
    public void DisablePhysics()
    {
        rb.isKinematic = true;  // �������� ����������
        rb.useGravity = false;  // ��������� ����������
    }

    // ���������� ������ �� ��������
    public void DetachFromParent()
    {
        transform.SetParent(null); // ���������� ������ �� ��������
    }

    // ������������� ������� ��� �������
    public void SetDropPosition(Vector3 position)
    {
        transform.position = position; // ���������� ������ � ������ �������
    }
}
