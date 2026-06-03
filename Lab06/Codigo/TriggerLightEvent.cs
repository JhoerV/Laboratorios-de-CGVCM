using UnityEngine;

public class TriggerLightEvent : MonoBehaviour
{
    [Header("Luz a controlar")]
    public Light luzObjetivo;

    [Header("Configuración")]
    public bool encenderAlEntrar = true;
    public bool apagarAlSalir = true;

    [Header("Tag del jugador")]
    public string tagJugador = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            if (luzObjetivo != null)
            {
                luzObjetivo.enabled = encenderAlEntrar;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            if (luzObjetivo != null && apagarAlSalir)
            {
                luzObjetivo.enabled = false;
            }
        }
    }
}