using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public string wallsName;
    private bool touchedOnce;
    public Color green;

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.name == wallsName)
        {
            if (touchedOnce == false)
            {
                touchedOnce = true;
                GameObject.Find(wallsName).GetComponent<Renderer>().material.SetColor("_EmissionColor", green);
            }
        }

    }

}
