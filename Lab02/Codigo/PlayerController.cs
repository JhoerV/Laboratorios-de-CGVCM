using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fuerzaMovimiento;
    public float maxVelocidad;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float movimiento = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb.velocity.x) < maxVelocidad)
        {
            rb.AddForce(new Vector3(movimiento * fuerzaMovimiento, 0, 0));
        }

        // Rotación visual
        transform.Rotate(0, 0, -movimiento * 2f);
    }
}
