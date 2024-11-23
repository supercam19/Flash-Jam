using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{
    public bool inTitle = false;

    void Start()
    {
        // Temp only
        LoadGame();
    }

    void LoadGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
