using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionCheck : MonoBehaviour
{
    public Transform player;
    public Transform exitPoint;
    public GameObject[] requirements;
    public GameObject finishText;
    private static GameObject[] staticRequirements;
    private static int totalCollectables = 7;
    private static int numCollected = 0;

    void Start()
    {
        staticRequirements = requirements;
        finishText.SetActive(false);
    }

    void Update()
    {
        if (numCollected >= totalCollectables)
        {
            if (!finishText.activeInHierarchy)
            {
                finishText.SetActive(true);
            }
            if(Vector3.Distance(player.position, exitPoint.position) < 5.0f)
            {
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }

    public static void ItemCollected(GameObject item)
    {
            
        staticRequirements[ParseNameForIndex(item.name)].GetComponent<GroceryListItem>().MarkCompleted();
        numCollected++;
    }

    private static int ParseNameForIndex(string name)
    {
        // ASCII: A = 65
        char last = name[name.Length - 1];
        return last - 65;
    }
    
}
