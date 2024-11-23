using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Rigidbody rb;
    public Transform groundCheck;
    public CharacterController cc;
    public float speed = 10;
    Vector3 movement = Vector3.zero;
    public bool grounded = false;
    float downVelocity = 0;
    public LayerMask groundMask;
    public float gravity = 20;
    public float jumpVelocity = 10;
    private float groundTimer = 0f;
    public float bhopTimer = 0.1f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        movement = transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        cc.Move(movement * Time.deltaTime * speed);
        //rb.linearVelocity = horizontal * groundSpeed * orientation.forward + vertical * groundSpeed * orientation.right;
        if(downVelocity < 0)
        {
            grounded = false;
            groundTimer = bhopTimer;
        }
        else
        {
            grounded = Physics.CheckSphere(groundCheck.position, 0.25f, groundMask);
        }

        if (!grounded)
        {
            downVelocity += gravity * Time.deltaTime;
            cc.Move(Vector3.down * downVelocity * Time.deltaTime);
        }
        if(grounded)
        {
            
            if(groundTimer > 0)
            {
                groundTimer -= Time.deltaTime;
            }
            else if (speed != 10)
            {
                speed = 10;
            }

            if (Input.GetKeyDown("space"))
            {
                downVelocity = -jumpVelocity;
                if (groundTimer > 0)
                {
                    speed= speed * 1.25f;
                }
                grounded = false;
            }
            else
            {
                downVelocity = 0;
            }
            
        }
    }
}
