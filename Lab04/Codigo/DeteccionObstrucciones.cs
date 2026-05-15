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

    // Transform para la obstrucción
    public Transform Obstruction;

    // Velocidad del zoom
    float zoomSpeed = 2f;

    void Start()
    {
        // Valor inicial para transform Obstruction
        Obstruction = Target;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
        ViewObstructed();
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

        // Control para permitir que solo se mueva la cámara cuando se presiona la tecla Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            // Controlar la rotación de la cámara con el mouse y la rotación del personaje
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    // Método para detectar obstrucciones
    void ViewObstructed()
    {
        // Se hace uso de Raycast para detectar si un objeto está en la línea de visión
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            // Si el objeto que está en la línea de visión no es el jugador
            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;

                // Usar shadow casting para ocultar la obstrucción pero mantener las sombras
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode =
                    UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                // Verificar distancia de la cámara y el jugador para decidir si acercarse o no
                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f &&
                    Vector3.Distance(transform.position, Target.position) >= 1.5f)
                {
                    // Zoom
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                // Activar el MeshRenderer del muro para que vuelva a ser visible
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode =
                    UnityEngine.Rendering.ShadowCastingMode.On;

                if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }
}
