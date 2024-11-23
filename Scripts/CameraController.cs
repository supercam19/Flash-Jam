using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
    }
}
