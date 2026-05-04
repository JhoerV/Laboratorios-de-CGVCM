using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase controla el comportamiento de una bala o proyectil en Unity
public class bala : MonoBehaviour
{
    // Velocidad a la que se moverá la bala
    public float velocidad;

    // Update se llama una vez por frame
    void Update()
    {
        // Mueve la bala hacia arriba (eje Y local)
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }
}

