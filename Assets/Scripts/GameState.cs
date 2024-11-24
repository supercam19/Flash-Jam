using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameState : MonoBehaviour
{
    [HideInInspector]
    public bool inTitle = false;
    
    public static float sensitivity = 100f;
    public static float volume = 1f;
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

    public static void SaveVolume(float value)
    {
        volume = value / 100;
    }

    public static string GetTime()
    {
        float time = Time.time - startTime;
        if (time < bestTime)
        {
            bestTime = time;
        }

        return FormatTimeBuilder(time);
    }

    public static string GetBestTime()
    {
        GetTime();
        return FormatTimeBuilder(bestTime);
    }

    private static string FormatTimeBuilder(float timeSecs)
    {
        int minutes = (int)(timeSecs / 60);
        timeSecs -= minutes * 60;
        int secs = (int)timeSecs;
        timeSecs -= secs;
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, secs, timeSecs);
    }
}
