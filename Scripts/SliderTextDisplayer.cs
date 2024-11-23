using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderTextDisplayer : MonoBehaviour
{

    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void OnSliderValueChanged(System.Single value)
    {
        Debug.Log(value);
        text.text = value.ToString("0");
    }
}
