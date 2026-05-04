using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Maneja las colisiones entre objetos
public class colisiones : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionjugador;
    public int scorevalue;

    private controlador gamecontroller;

    void Start()
    {
        gamecontroller = GameObject.FindWithTag("GameController")
                                  .GetComponent<controlador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.CompareTag("nave"))
        {
            Instantiate(explosionjugador,
                        other.transform.position,
                        other.transform.rotation);
        }

        gamecontroller.addscore(scorevalue);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

