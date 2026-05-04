using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movimiento constante
public class mover : MonoBehaviour
{
    public float velocidad;

    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }
}
