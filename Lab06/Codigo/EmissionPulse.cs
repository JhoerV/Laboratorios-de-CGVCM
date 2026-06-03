using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class EmissionPulse : MonoBehaviour
{
    [Header("Color de emisión")]
    public Color colorEmision = Color.cyan;

    [Header("Intensidad")]
    public float intensidadMinima = 0.5f;
    public float intensidadMaxima = 3f;
    public float velocidadPulso = 2f;

    private Renderer rend;
    private Material material;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        material = rend.material;

        material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        float pulso = Mathf.PingPong(Time.time * velocidadPulso, 1f);
        float intensidadActual = Mathf.Lerp(intensidadMinima, intensidadMaxima, pulso);

        material.SetColor("_EmissionColor", colorEmision * intensidadActual);
    }
}