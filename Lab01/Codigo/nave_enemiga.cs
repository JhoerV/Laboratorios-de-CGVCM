using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Disparo automático del enemigo
public class nave_enemiga : MonoBehaviour
{
    public GameObject shot;
    public Transform shotspanw;

    public float delay;
    public float firerate;

    void Start()
    {
        InvokeRepeating("Fire", delay, firerate);
    }

    void Fire()
    {
        Instantiate(shot, shotspanw.position, shotspanw.rotation);
    }
}

