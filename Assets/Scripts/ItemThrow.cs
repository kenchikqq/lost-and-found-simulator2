using UnityEngine;

public class ItemThrow : MonoBehaviour
{
    public void Throw(Transform cameraTransform)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Применяем силу для выброса предмета
            rb.AddForce(cameraTransform.forward * 5f, ForceMode.Impulse);
            Debug.Log("Предмет выброшен.");
        }
        else
        {
            Debug.LogWarning("Rigidbody не найден на предмете!");
        }
    }
}
