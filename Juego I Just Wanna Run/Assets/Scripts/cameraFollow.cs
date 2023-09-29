using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // Referencia al transform del personaje a seguir
    public float smoothSpeed = 0.125f; // Velocidad suave de seguimiento, ajusta según tu preferencia
    public Vector3 offset;           // Desplazamiento de la cámara con respecto al personaje

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

