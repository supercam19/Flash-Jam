using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;
    private Transform cam;
    public Transform orientation;

    [SerializeField] private float groundSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        player = gameObject.transform;
        cam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = horizontal * groundSpeed * orientation.forward + vertical * groundSpeed * orientation.right;
    }
}
