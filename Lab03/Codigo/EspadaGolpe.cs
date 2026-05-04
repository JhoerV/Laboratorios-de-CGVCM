using UnityEngine;

public class EspadaGolpe : MonoBehaviour
{
    public float fuerzaGolpe;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direccion = collision.transform.position - transform.position;

                rb.AddForce(direccion.normalized * fuerzaGolpe, ForceMode.Impulse);
            }
        }
    }
}