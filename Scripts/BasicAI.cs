using UnityEngine;

public class BasicAI : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;

    private float lastTickTime = 0;
    public float tickRate = 5f;
    private const float moveChance = 0.1f;
    public float speed = 5f;

    private Vector3 target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        Random.InitState(0);
        rb.freezeRotation = true;
        rb.linearDamping = 0.2f;
    }

    void Update()
    {
        if (Time.time - lastTickTime > tickRate)
        {
            Tick();
            lastTickTime = Time.time;
        }

        // if (target.magnitude > 0)
        // {
        //     Vector3 direction = target - transform.position;
        //     Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 0.1f, 0.0f);
        //     transform.rotation = Quaternion.LookRotation(newDirection);
        // }
    }

    private void Tick()
    {
        Vector3 lookDir = Vector3.zero;
        if (Random.value < 0.25f)
        {
            target = new Vector3(speed, 0, 0);
            lookDir = new Vector3(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (Random.value < 0.5f)
        {
            target = new Vector3(-speed, 0, 0);
            lookDir = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        }
        else if (Random.value < 0.75f)
        {
            target = new Vector3(0, 0, speed);
            lookDir = new Vector3(transform.rotation.x, 270, transform.rotation.z);
        }
        else
        {
            target = new Vector3(0, 0, -speed);
            lookDir = new Vector3(transform.rotation.x, 90, transform.rotation.z);
        }

        transform.rotation = Quaternion.Euler(lookDir);
        Invoke(nameof(Move), 1f);
    }

    private void Move()
    {
        rb.linearVelocity = target;
        target = Vector3.zero;
    }
}
