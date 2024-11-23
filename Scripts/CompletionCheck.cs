using UnityEngine;

public class CompletionCheck : MonoBehaviour
{
    public Transform exitPoint;
    public GameObject[] requirements;
    private static bool[] collectedItems = {false, false, false, false, false, false, false};

    private static GameObject[] staticRequirements;
    private static Transform staticExitPoint;

    void Start()
    {
        staticRequirements = requirements;
        staticExitPoint = exitPoint;
    }
    
}
