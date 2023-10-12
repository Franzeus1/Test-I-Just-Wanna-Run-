using UnityEngine;

public class DisplayResolution : MonoBehaviour
{
    void Start()
    {
        // Obtiene la resolución actual en tiempo de ejecución
        int currentWidth = Screen.currentResolution.width;
        int currentHeight = Screen.currentResolution.height;

        // Muestra la resolución en la consola
        Debug.Log("Resolución actual: " + currentWidth + "x" + currentHeight);
    }
}
