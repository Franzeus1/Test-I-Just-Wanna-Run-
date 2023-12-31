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

    private Animator animator;
    private SpriteRenderer playerSprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        velocidadActual = velocidadBase;
        playerSprite = GetComponent<SpriteRenderer>();

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

        if (Input.GetKey(KeyCode.A))
        {
            movimientoHorizontal = -1f;
        }



        else if (Input.GetKey(KeyCode.D))
        {
            movimientoHorizontal = 1f;
        }
        if (movimientoHorizontal > 0)
        {
            flip(true);

        }
        else if (movimientoHorizontal < 0)
        { flip(false); }


        Vector2 velocidad = new Vector2(movimientoHorizontal * velocidadActual, rb.velocity.y);
        rb.velocity = velocidad;
        animator.SetFloat("a", Mathf.Abs(movimientoHorizontal));



        // Permitir un salto si est� en contacto con el suelo
        if (puedeSaltar && Input.GetKey("space"))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            puedeSaltar = false;
        }
    }

    void flip(bool flipped)
    {
        if (flipped == true)
        {
            playerSprite.flipX = false;

        }
        else if (flipped == false)
        {
            playerSprite.flipX = true;
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
