using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public float velocidadBase = 5f;         // Velocidad base del personaje
    public float velocidadIncremental = 2f;  // Incremento de velocidad al mantener presionada la tecla
    public float fuerzaSalto = 10f;          // Fuerza del salto
    private float velocidadActual;           // Velocidad actual del personaje
    private Rigidbody2D rb;
    private bool puedeSaltar = true;        // Variable para controlar si se puede saltar

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadActual = velocidadBase;
    }

    void Update()
    {
        // Cambia la velocidad al presionar "Shift"
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidadActual *= 2f; // Duplica la velocidad
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadActual /= 2f; // Restablece la velocidad a su valor base
        }

        // Mover el personaje horizontalmente
        float movimientoHorizontal = 0f;

        if (Input.GetKey("a"))
        {
            movimientoHorizontal = -1f;
        }
        else if (Input.GetKey("d"))
        {
            movimientoHorizontal = 1f;
        }

        Vector2 velocidad = new Vector2(movimientoHorizontal * velocidadActual, rb.velocity.y);
        rb.velocity = velocidad;

        // Permitir un salto si está en contacto con el suelo
        if (puedeSaltar && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            puedeSaltar = false;
        }
    }

    // Detecta colisiones con el suelo para habilitar el salto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            puedeSaltar = true;
        }
    }
}




