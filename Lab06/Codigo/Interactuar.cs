using UnityEngine;

public class Interactuar : MonoBehaviour
{
    [Header("Configuración general")]
    public string nombreInteraccion = "Interruptor de luz";

    [Header("Luz principal")]
    public bool controlarLuz = true;
    public Light luzHabitacion;

    [Header("Objetos que se activan o desactivan")]
    public GameObject[] objetosActivables;

    [Header("Material emisivo")]
    public Renderer[] objetosConEmision;
    public Color colorEmision = Color.yellow;
    public float intensidadEmision = 2f;

    [Header("Sonido")]
    public AudioSource sonidoInterruptor;

    private bool encendido = false;

    private void Start()
    {
        AplicarEstadoInicial();
    }

    public void EjecutarInteraccion()
    {
        encendido = !encendido;

        CambiarEstadoLuz();
        CambiarEstadoObjetos();
        CambiarEstadoEmision();
        ReproducirSonido();

        Debug.Log(nombreInteraccion + " estado: " + (encendido ? "Encendido" : "Apagado"));
    }

    private void AplicarEstadoInicial()
    {
        if (luzHabitacion != null)
        {
            encendido = luzHabitacion.enabled;
        }

        CambiarEstadoObjetos();
        CambiarEstadoEmision();
    }

    private void CambiarEstadoLuz()
    {
        if (controlarLuz && luzHabitacion != null)
        {
            luzHabitacion.enabled = encendido;
        }
    }

    private void CambiarEstadoObjetos()
    {
        if (objetosActivables == null)
        {
            return;
        }

        foreach (GameObject obj in objetosActivables)
        {
            if (obj != null)
            {
                obj.SetActive(encendido);
            }
        }
    }

    private void CambiarEstadoEmision()
    {
        if (objetosConEmision == null)
        {
            return;
        }

        foreach (Renderer rend in objetosConEmision)
        {
            if (rend != null)
            {
                Material material = rend.material;

                if (encendido)
                {
                    material.EnableKeyword("_EMISSION");
                    material.SetColor("_EmissionColor", colorEmision * intensidadEmision);
                }
                else
                {
                    material.SetColor("_EmissionColor", Color.black);
                    material.DisableKeyword("_EMISSION");
                }
            }
        }
    }

    private void ReproducirSonido()
    {
        if (sonidoInterruptor != null)
        {
            sonidoInterruptor.Play();
        }
    }
}
