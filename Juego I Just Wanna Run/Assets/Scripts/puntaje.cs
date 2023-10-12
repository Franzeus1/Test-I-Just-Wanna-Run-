using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puntaje : MonoBehaviour
{
    private float puntos;

    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        puntos += Time.deltaTime;
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float PuntosEntrada)
    {
        puntos += PuntosEntrada;
    }

}
