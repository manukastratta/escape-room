using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSuccess : MonoBehaviour
{
    public Color green;
    public GameObject keyShape;
    public GameObject door;

    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject == keyShape)
        {
            GetComponent<Renderer>().material.color = green;
            target.GetComponent<Renderer>().material.color = green;
            keyShape.transform.parent = door.transform;


            GetComponent<Renderer>().material.SetColor("_EmissionColor", green);
        }
    }
}
