using UnityEngine;

public class SceneLightManager : MonoBehaviour
{
    [Header("Luces principales")]
    public Light luzPrincipal;
    public Light luzComputadora;
    public Light luzAmbiente;

    [Header("Colores")]
    public Color colorNoche = new Color(0.05f, 0.05f, 0.15f);
    public Color colorCalido = new Color(1f, 0.75f, 0.35f);
    public Color colorTecnologico = new Color(0.1f, 0.7f, 1f);

    [Header("Intensidades")]
    public float intensidadNoche = 0.3f;
    public float intensidadCalida = 2.5f;
    public float intensidadTecnologica = 1.8f;

    private void Start()
    {
        ActivarModoNoche();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivarModoNoche();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivarModoCalido();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivarModoTecnologico();
        }
    }

    public void ActivarModoNoche()
    {
        RenderSettings.ambientLight = colorNoche;

        if (luzPrincipal != null)
        {
            luzPrincipal.enabled = false;
        }

        if (luzComputadora != null)
        {
            luzComputadora.enabled = true;
            luzComputadora.color = colorTecnologico;
            luzComputadora.intensity = intensidadTecnologica;
        }

        if (luzAmbiente != null)
        {
            luzAmbiente.enabled = true;
            luzAmbiente.color = colorNoche;
            luzAmbiente.intensity = intensidadNoche;
        }
    }

    public void ActivarModoCalido()
    {
        RenderSettings.ambientLight = colorCalido * 0.3f;

        if (luzPrincipal != null)
        {
            luzPrincipal.enabled = true;
            luzPrincipal.color = colorCalido;
            luzPrincipal.intensity = intensidadCalida;
        }

        if (luzComputadora != null)
        {
            luzComputadora.enabled = false;
        }

        if (luzAmbiente != null)
        {
            luzAmbiente.enabled = true;
            luzAmbiente.color = colorCalido;
            luzAmbiente.intensity = intensidadNoche;
        }
    }

    public void ActivarModoTecnologico()
    {
        RenderSettings.ambientLight = colorTecnologico * 0.2f;

        if (luzPrincipal != null)
        {
            luzPrincipal.enabled = false;
        }

        if (luzComputadora != null)
        {
            luzComputadora.enabled = true;
            luzComputadora.color = colorTecnologico;
            luzComputadora.intensity = intensidadTecnologica;
        }

        if (luzAmbiente != null)
        {
            luzAmbiente.enabled = true;
            luzAmbiente.color = colorTecnologico;
            luzAmbiente.intensity = intensidadNoche;
        }
    }
}