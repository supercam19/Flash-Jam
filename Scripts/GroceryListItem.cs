using UnityEngine;
using TMPro;

public class GroceryListItem : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void MarkCompleted()
    {
        text.text = "<s>" + text.text + "</s>";
    }
}
