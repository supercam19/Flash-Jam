using UnityEngine;
using UnityEngine.UI;

public class OptionsPageManager : MonoBehaviour
{
    public GameObject titlePage;
    public GameObject optionsPage;

    public void OpenOptionsPage()
    {
        titlePage.SetActive(false);
        optionsPage.SetActive(true);
    }

    public void CloseOptionsPage()
    {
        optionsPage.SetActive(false);
        titlePage.SetActive(true);
    }
}
