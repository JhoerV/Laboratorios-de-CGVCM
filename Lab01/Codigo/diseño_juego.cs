using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controlador principal del juego
public class controlador : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnvalues;

    private int score;

    public Text scoretext;

    void Start()
    {
        score = 0;
        Updatescore();
        spawn();
    }

    void spawn()
    {
        Vector3 spawnposition = new Vector3(
            Random.Range(-spawnvalues.x, spawnvalues.x),
            spawnvalues.y,
            spawnvalues.z
        );

        Instantiate(hazard, spawnposition, Quaternion.identity);
    }

    public void addscore(int value)
    {
        score += value;
        Updatescore();
    }

    void Updatescore()
    {
        scoretext.text = "Score: " + score;
    }
}
