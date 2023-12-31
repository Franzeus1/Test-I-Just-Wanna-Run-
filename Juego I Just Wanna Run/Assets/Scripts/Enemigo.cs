using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    public float velocidad;

    public bool esDerecha;

    public float contadorT;
    public float tiempoParaCambiar = 4f;

    // Start is called before the first frame update
    void Start()
    {
        contadorT = tiempoParaCambiar;




    }

    // Update is called once per frame
    void Update()
    {
        if (esDerecha == true) 
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }  
        if (esDerecha == false) 
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        contadorT -= Time.deltaTime;
        if (contadorT <= 0) 
        {
            contadorT = tiempoParaCambiar;
            esDerecha = !esDerecha;

      
        }

        
    }
}
