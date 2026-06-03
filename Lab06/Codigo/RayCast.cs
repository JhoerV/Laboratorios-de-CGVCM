using UnityEngine;

public class RayCast : MonoBehaviour
{
    [Header("Configuración del Raycast")]
    public Camera camaraPrincipal;
    public float rango = 10f;
    public KeyCode teclaInteraccion = KeyCode.E;

    [Header("Depuración")]
    public bool mostrarRaycast = true;
    public Color colorRaycast = Color.blue;

    private void Start()
    {
        if (camaraPrincipal == null)
        {
            camaraPrincipal = Camera.main;
        }
    }

    private void Update()
    {
        DetectarInteraccion();
    }

    private void DetectarInteraccion()
    {
        if (camaraPrincipal == null)
        {
            return;
        }

        Ray rayo = new Ray(camaraPrincipal.transform.position, camaraPrincipal.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit, rango))
        {
            Interactuar objetoInteractuable = hit.collider.GetComponent<Interactuar>();

            if (objetoInteractuable != null)
            {
                if (Input.GetKeyDown(teclaInteraccion))
                {
                    objetoInteractuable.EjecutarInteraccion();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!mostrarRaycast)
        {
            return;
        }

        if (camaraPrincipal == null)
        {
            camaraPrincipal = Camera.main;
        }

        if (camaraPrincipal != null)
        {
            Gizmos.color = colorRaycast;
            Gizmos.DrawRay(camaraPrincipal.transform.position, camaraPrincipal.transform.forward * rango);
        }
    }
}
