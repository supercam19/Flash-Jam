using UnityEngine;

public class Interact : MonoBehaviour
{
    public LayerMask itemMask;
    public LayerMask goalMask;
    public Transform cam;
    public Interactable i;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Does the ray intersect any objects excluding the player layer
        if (Input.GetMouseButtonDown(0)&& Physics.Raycast(transform.position, cam.TransformDirection(Vector3.forward), out hit, 5, itemMask))
        {
            print("Hit");
            i = hit.transform.GetComponent<Interactable>();
        }
        else if (i != null && Input.GetMouseButton(0))
        {
            i.Hold(transform.position + cam.TransformDirection(Vector3.forward)*3);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            i = null;
        }
        if (Input.GetKey("e") && Physics.Raycast(transform.position, cam.TransformDirection(Vector3.forward), out hit, 5, goalMask))
        {
            print("Hit");
            hit.transform.GetComponent<GoalItem>().Grab();
        }
    }
}
