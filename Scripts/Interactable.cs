using UnityEngine;

public class Interactable : MonoBehaviour
{
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Hold(Vector3 goalPosition)
    {
        Vector3 diff = transform.position - goalPosition;
        float distance = Vector3.Distance(transform.position,goalPosition);
        rb.AddForce(-diff*distance, ForceMode.VelocityChange);
    }
}
