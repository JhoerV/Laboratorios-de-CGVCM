using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // Obteniendo ejes de coordenadas verticales y horizontales.
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        // Vector de movimiento
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;

        // Aplicando transform para que el personaje se mueva según el vector
        transform.Translate(playerMovement, Space.Self);
    }
}