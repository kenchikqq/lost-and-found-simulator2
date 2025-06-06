using UnityEngine;

namespace MyGame.Items  // ������������ ��� ��� ���� �������, ��������� � ����������
{
    public class ItemTrue : MonoBehaviour
    {
        [HideInInspector] public Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }
        }

        // ����� ��� ����������� ������� �� ��������
        public void DetachItem()
        {
            transform.SetParent(null); // ���������� ������ �� ��������
        }

        public void ApplyPhysics(Vector3 throwDirection, float force)
        {
            if (rb != null)
            {
                rb.AddForce(throwDirection * force, ForceMode.Impulse); // ��������� �������
            }
        }
    }
}
