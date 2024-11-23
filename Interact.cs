using UnityEngine;

public class Interact : MonoBehaviour
{
    public LayerMask groundMask;
    public Transform cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
