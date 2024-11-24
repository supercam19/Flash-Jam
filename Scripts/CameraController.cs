using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float sensX;
    public float sensY;

    private float rotX;
    private float rotY;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        sensX = GameState.sensitivity * 5;
        sensY = GameState.sensitivity * 5;
    }
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotX += mouseX;
        rotY -= mouseY;
        rotY = Mathf.Clamp(rotY, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(rotY, rotX, 0);
        player.rotation = Quaternion.Euler(0, rotX, 0);
    }
}
