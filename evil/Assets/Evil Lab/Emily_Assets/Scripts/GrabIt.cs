using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabIt : MonoBehaviour
{
    public GameObject keyShape;
    public GameObject grabberCube;


    // Start is called before the first frame update
    private void Start()
    {

    }

    public void Grabit()
    {
        keyShape.transform.position = grabberCube.transform.position;
        keyShape.transform.parent = grabberCube.transform;
    }
}
