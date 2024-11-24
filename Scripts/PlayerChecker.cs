using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<CompletionCheck>().Triggered(gameObject.name);
        }
    }
}
