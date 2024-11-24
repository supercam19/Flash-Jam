using UnityEngine;

public class Interactable : MonoBehaviour
{
    AudioManager am;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void Hold(Vector3 goalPosition)
    {
        Vector3 diff = transform.position - goalPosition;
        float distance = Vector3.Distance(transform.position,goalPosition);
        rb.AddForce(-diff*distance, ForceMode.VelocityChange);
    }
    void OnCollisionEnter(Collision collision)
    {
        am.Play("hit");
    }
}
