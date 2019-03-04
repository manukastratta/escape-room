using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabIt : MonoBehaviour
{
    public GameObject keyShape;
    public GameObject grabberCube;
    private Vector3 originalSize;


    // Start is called before the first frame update
    private void Start()
    {
        originalSize = transform.localPosition;

    }

    public void Grabit()
    {
        keyShape.transform.localPosition = grabberCube.transform.position;
        keyShape.transform.parent = grabberCube.transform;
    }
}
