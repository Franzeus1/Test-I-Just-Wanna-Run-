using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguirEnemigo : MonoBehaviour
{
    Vector2 Enemigopos;
    public GameObject PlayerM;
    bool perseguirP;
    public int vel;
    public float velocidad;

    public bool esDerecha;
   
    public float contadorT;
    public float tiempoParaCambiar = 4f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        contadorT = tiempoParaCambiar;
        spriteRenderer = GetComponent<SpriteRenderer>();



    }




    // Update is called once per frame
    void Update()
    {
        if (esDerecha == true)
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            //transform.localScale = new Vector3(1, 1, 1);
            spriteRenderer.flipX = false; // Voltea el sprite hacia la derecha
        }
        if (esDerecha == false)
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
            //transform.localScale = new Vector3(-1, 1, 1);
            spriteRenderer.flipX = true;
        }

        contadorT -= Time.deltaTime;
        if (contadorT <= 0)
        {
            contadorT = tiempoParaCambiar;
            esDerecha = !esDerecha;


        }

        spriteRenderer.flipX = !esDerecha;

        if (perseguirP)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemigopos, vel * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Enemigopos) > 4f)
        {
            perseguirP = false;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("PJ"))
        {
            Enemigopos = PlayerM.transform.position;
            perseguirP = true;
            
            contadorT = tiempoParaCambiar;

        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("PJ"))
        {
            Enemigopos=PlayerM.transform.position;
            perseguirP &= false;

            


        }
    }

}