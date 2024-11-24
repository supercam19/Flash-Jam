using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionCheck : MonoBehaviour
{
    public Transform player;
    public Transform exitPoint;
    public GameObject[] requirements;
    public GameObject finishText;
    public GameObject block;
    private static GameObject[] staticRequirements;
    private static int totalCollectables = 7;
    private static int numCollected = 0;

    public bool payed = true;
    public GameObject checkOut;
    public GameObject alarm;
    void Start()
    {
        staticRequirements = requirements;
        finishText.SetActive(false);
        block.SetActive(false);
        checkOut.SetActive(false);
        alarm.SetActive(false);
    }

    void Update()
    {
        if (numCollected >= totalCollectables)
        {
            if (!finishText.activeInHierarchy)
            {
                finishText.SetActive(true);
                payed = false;
                checkOut.SetActive(true);
                alarm.SetActive(true);
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
    public void Triggered(string name)
    {
        print(name);
        if (!payed)
        {
            if(name == "CheckOut")
            {
                payed = true;
                return;
            }
            if (name == "AlertLine")
            {
                print("ALERT");
                block.SetActive(true);
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("vov");
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("alarm");
                GameObject.Find("Directional Light").GetComponent<Light>().color = Color.red;
                checkOut.SetActive(false);
                alarm.SetActive(false);
            }
        }
    }
}
