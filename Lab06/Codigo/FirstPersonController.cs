using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 5f;
    public float velocidadCorrer = 8f;
    public float fuerzaGravedad = -9.81f;
    public float fuerzaSalto = 1.5f;

    [Header("Mouse / Cámara")]
    public Transform camaraJugador;
    public float sensibilidadMouse = 120f;
    public float limiteVistaVertical = 80f;

    [Header("Detección de suelo")]
    public Transform puntoSuelo;
    public float radioSuelo = 0.3f;
    public LayerMask capaSuelo;

    private CharacterController controller;
    private Vector3 velocidadVertical;
    private bool estaEnSuelo;
    private float rotacionX = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        ControlarCamara();
        ControlarMovimiento();
        AplicarGravedad();
    }

    private void ControlarCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -limiteVistaVertical, limiteVistaVertical);

        camaraJugador.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void ControlarMovimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * x + transform.forward * z;

        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadMovimiento;

        controller.Move(direccion * velocidadActual * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && estaEnSuelo)
        {
            velocidadVertical.y = Mathf.Sqrt(fuerzaSalto * -2f * fuerzaGravedad);
        }
    }

    private void AplicarGravedad()
    {
        estaEnSuelo = Physics.CheckSphere(puntoSuelo.position, radioSuelo, capaSuelo);

        if (estaEnSuelo && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }

        velocidadVertical.y += fuerzaGravedad * Time.deltaTime;

        controller.Move(velocidadVertical * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        if (puntoSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
        }
    }
}
