using UnityEngine;

public class ItemThrow : MonoBehaviour
{
    public void Throw(Transform cameraTransform)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(cameraTransform.forward * 2f, ForceMode.Impulse);
            Debug.Log("Предмет выброшен.");
        }
    }
}
