using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform orientation;
    public float sensX;
    public float sensY;

    private float rotX;
    private float rotY;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);

        rotX += mouseX;
        rotY -= mouseY;
        rotY = Mathf.Clamp(rotY, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(rotY, rotX, 0);
        orientation.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
