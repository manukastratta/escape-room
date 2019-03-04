using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        GameObject handCylinder = GameObject.Find("HandCylinder");
        GameObject handTrigger = GameObject.Find("HandTrigger");
        handCylinder.GetComponent<MeshRenderer>().enabled = true;
        handTrigger.GetComponent<MeshRenderer>().enabled = true;
        gameObject.SetActive(false);
    }
}
