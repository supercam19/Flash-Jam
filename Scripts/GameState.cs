using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameState : MonoBehaviour
{
    [HideInInspector]
    public bool inTitle = false;

    [HideInInspector] 
    public static float sensitivity = 100f;

    void Start()
    {
        inTitle = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public static void LoadGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("SampleScene");
    }

    public static void SaveSensitivity(float value)
    {
        sensitivity = value;
    }
    
}
