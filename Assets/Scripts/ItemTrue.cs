using UnityEngine;

namespace MyGame.Items  // Пространство имён для всех классов, связанных с предметами
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

        // Метод для отвязывания объекта от родителя
        public void DetachItem()
        {
            transform.SetParent(null); // Отвязываем объект от родителя
        }

        public void ApplyPhysics(Vector3 throwDirection, float force)
        {
            if (rb != null)
            {
                rb.AddForce(throwDirection * force, ForceMode.Impulse); // Применяем импульс
            }
        }
    }
}
