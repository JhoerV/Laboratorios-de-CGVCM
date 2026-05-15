using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    void Start()
    {
        ActivateCamera(camera1);
    }

    void Update()
    {
        Debug.Log("Update está funcionando");

        if (Input.GetKeyDown(KeyCode.T))
        {
            ActivateCamera(camera1);
            Debug.Log("Camara 1 activa");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            ActivateCamera(camera2);
            Debug.Log("Camara 2 activa");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            ActivateCamera(camera3);
            Debug.Log("Camara 3 activa");
        }
    }

    void ActivateCamera(Camera camToActivate)
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);

        camToActivate.gameObject.SetActive(true);
    }
}