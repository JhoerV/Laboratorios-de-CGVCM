using UnityEngine;

public class ataque : MonoBehaviour
{
    public float angulo = 90f;
    public float velocidad = 360f;
    public KeyCode teclaAtaque = KeyCode.Space;

    private bool atacando = false;
    private float rotado = 0f;
    private Quaternion rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaAtaque) && !atacando)
        {
            atacando = true;
            rotado = 0f;
        }

        if (atacando)
        {
            float paso = velocidad * Time.deltaTime;

            transform.Rotate(0f, 0f, -paso);
            rotado += paso;

            if (rotado >= angulo)
            {
                atacando = false;
                transform.rotation = rotacionInicial;
            }
        }
    }
}