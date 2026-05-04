using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform camara;
    public float velocidadParallax;

    private Vector3 ultimaPosCamara;

    void Start()
    {
        ultimaPosCamara = camara.position;
    }

    void Update()
    {
        Vector3 movimiento = camara.position - ultimaPosCamara;

        transform.position += new Vector3(
            movimiento.x * velocidadParallax,
            movimiento.y * velocidadParallax,
            0
        );

        ultimaPosCamara = camara.position;
    }
}
