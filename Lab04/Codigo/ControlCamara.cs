using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    // Velocidad de rotación de la cámara
    float rotationSpeed = 1;

    // Transforms para el jugador y Target, que es el objetivo de la cámara
    public Transform Target, Player;

    // Valores de los ejes del mouse
    float mouseX, mouseY;

    void Start()
    {
        // Remover el cursor
        Obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        // Control de la cámara con el mouse
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        // Límites para que la cámara no se voltee
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        // La cámara se fija en un objetivo
        transform.LookAt(Target);

        // Controlar la rotación de la cámara con el mouse y la rotación del personaje
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
