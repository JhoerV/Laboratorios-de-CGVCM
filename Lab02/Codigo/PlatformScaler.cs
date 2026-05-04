using UnityEngine;

public class PlatformScaler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.localScale += new Vector3(1f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            transform.localScale -= new Vector3(1f, 0, 0);
        }
    }
}