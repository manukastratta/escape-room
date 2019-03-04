using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermoCountdown : MonoBehaviour
{
    public Color black;
    public float waitTime = 2.0f;
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            GetComponent<Renderer>().material.color = black;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", black);
        }
    }
}


