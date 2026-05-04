using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 posicionInicial;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Final"))
        {
            foreach (ContactPoint contacto in collision.contacts)
            {
                if (Vector3.Dot(contacto.normal, Vector3.up) > 0.5f)
                {
                    transform.position = posicionInicial;
                    rb.velocity = Vector3.zero;
                    break;
                }
            }
        }
    }
}
