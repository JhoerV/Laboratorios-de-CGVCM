using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    [Header("Configuración del parpadeo")]
    public bool activarParpadeo = true;
    public float intensidadMinima = 0.5f;
    public float intensidadMaxima = 3f;
    public float velocidadParpadeo = 8f;

    private Light luz;
    private float tiempoAleatorio;

    private void Start()
    {
        luz = GetComponent<Light>();
        tiempoAleatorio = Random.Range(0f, 100f);
    }

    private void Update()
    {
        if (!activarParpadeo || luz == null)
        {
            return;
        }

        float ruido = Mathf.PerlinNoise(Time.time * velocidadParpadeo, tiempoAleatorio);
        luz.intensity = Mathf.Lerp(intensidadMinima, intensidadMaxima, ruido);
    }
}