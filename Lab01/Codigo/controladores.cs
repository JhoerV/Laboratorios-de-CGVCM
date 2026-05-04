using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control del jugador
public class controladores : MonoBehaviour
{
    private Rigidbody rig;

    public float velocidad = 5f;

    public float limiteXMin;
    public float limiteXMax;
    public float limiteZMin;
    public float limiteZMax;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 0.5f;
    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(
            movehorizontal * velocidad,
            0f,
            movevertical * velocidad
        );

        rig.velocity = movimento;

        Vector3 posicionLimite = rig.position;

        posicionLimite.x = Mathf.Clamp(posicionLimite.x, limiteXMin, limiteXMax);
        posicionLimite.z = Mathf.Clamp(posicionLimite.z, limiteZMin, limiteZMax);

        rig.position = posicionLimite;
    }
}

