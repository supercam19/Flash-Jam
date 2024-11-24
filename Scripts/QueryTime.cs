using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QueryTime : MonoBehaviour
{
    private TextMeshProUGUI text;

    public bool queryBestTime = false;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (queryBestTime)
        {
            text.text = "Best time: " + GameState.GetBestTime();
        }
        else
        {
            text.text = "Your time: " + GameState.GetTime();
        }
    }
}
