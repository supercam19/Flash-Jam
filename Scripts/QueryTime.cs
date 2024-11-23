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
            text.text = GameState.GetBestTime();
        }
        else
        {
            text.text = GameState.GetTime();
        }
    }
}
