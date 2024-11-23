using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameState : MonoBehaviour
{
    [HideInInspector]
    public bool inTitle = false;
    
    public static float sensitivity = 100f;
    public static float startTime = 0;
    public static float bestTime = float.MaxValue;
    

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
        startTime = Time.time;
    }

    public static void SaveSensitivity(float value)
    {
        sensitivity = value;
    }
    
}
