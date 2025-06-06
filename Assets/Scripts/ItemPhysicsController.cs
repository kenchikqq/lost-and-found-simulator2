using UnityEngine;

public class ItemPhysicsController : MonoBehaviour
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>(); // Если Rigidbody отсутствует, добавляем его
        }
        rb.isKinematic = true; // По умолчанию физика отключена
        rb.useGravity = false; // По умолчанию отключена гравитация
    }

    // Включаем физику при выбросе
    public void EnablePhysics()
    {
        rb.isKinematic = false;  // Отключаем кинематику
        rb.useGravity = true;    // Включаем гравитацию
    }

    // Отключаем физику (при осмотре предмета)
    public void DisablePhysics()
    {
        rb.isKinematic = true;  // Включаем кинематику
        rb.useGravity = false;  // Отключаем гравитацию
    }

    // Отвязываем объект от родителя
    public void DetachFromParent()
    {
        transform.SetParent(null); // Отвязываем объект от родителя
    }

    // Устанавливаем позицию при выбросе
    public void SetDropPosition(Vector3 position)
    {
        transform.position = position; // Перемещаем объект в нужную позицию
    }
}
