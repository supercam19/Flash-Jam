using UnityEngine;

public class GoalItem : MonoBehaviour
{
    public void Grab()
    {
        print("Picked Up " + this.name);
        CompletionCheck.ItemCollected(this.gameObject);
        Destroy(gameObject);
    }
}
