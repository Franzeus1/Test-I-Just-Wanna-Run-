using UnityEngine;

public class DisplayResolution : MonoBehaviour
{
    void Start()
    {
        // Obtiene la resoluci�n actual en tiempo de ejecuci�n
        int currentWidth = Screen.currentResolution.width;
        int currentHeight = Screen.currentResolution.height;

        // Muestra la resoluci�n en la consola
        Debug.Log("Resoluci�n actual: " + currentWidth + "x" + currentHeight);
    }
}
