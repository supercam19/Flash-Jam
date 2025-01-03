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

    bool startCheckoutTimer = false;
    public float checkoutTimer = 3;
    public bool payed = true;
    public GameObject checkOut;
    public GameObject alarm;
    public GameObject payingText;
    void Start()
    {
        staticRequirements = requirements;
        finishText.SetActive(false);
        block.SetActive(false);
        checkOut.SetActive(false);
        alarm.SetActive(false);
        payingText.SetActive(false);
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
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("vov");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("GameOver");
            }
            
        }
        if (startCheckoutTimer && checkoutTimer > 0)
        {
            checkoutTimer -= Time.deltaTime;
            if (checkoutTimer < 0)
            {
                payed = true;
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("check");
                block.SetActive(false);
                checkOut.SetActive(false);
                alarm.SetActive(false);
                payingText.SetActive(false);
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
                payingText.SetActive(true);
                startCheckoutTimer = true;
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
            if (name == "AntiCheckOut")
            {
                payingText.SetActive(false);
                checkoutTimer = 3;
                startCheckoutTimer = false;
            }
        }
    }
}
