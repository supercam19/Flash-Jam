using UnityEngine;

public class GoalItem : MonoBehaviour
{
    public void Grab()
    {
        print("Picked Up " + this.name);
        CompletionCheck.ItemCollected(this.gameObject);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("check");
        Destroy(gameObject);
    }
}
