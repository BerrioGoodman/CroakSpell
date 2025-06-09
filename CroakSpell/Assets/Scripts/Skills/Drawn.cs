using UnityEngine;

public class Drawn : MonoBehaviour
{
    public static bool drawn = false;
    public static bool isDrawn => drawn;
    public void Toggle()
    {
        drawn = !drawn;
    }
}
