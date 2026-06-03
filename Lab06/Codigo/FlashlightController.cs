using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [Header("Linterna")]
    public Light linterna;

    [Header("Controles")]
    public KeyCode teclaLinterna = KeyCode.F;

    [Header("Sonido")]
    public AudioSource sonidoLinterna;

    private bool encendida = false;

    private void Start()
    {
        if (linterna != null)
        {
            linterna.enabled = encendida;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(teclaLinterna))
        {
            CambiarEstadoLinterna();
        }
    }

    private void CambiarEstadoLinterna()
    {
        encendida = !encendida;

        if (linterna != null)
        {
            linterna.enabled = encendida;
        }

        if (sonidoLinterna != null)
        {
            sonidoLinterna.Play();
        }
    }
}
