using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Restarter : MonoBehaviour
{
    public static void LoadTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
