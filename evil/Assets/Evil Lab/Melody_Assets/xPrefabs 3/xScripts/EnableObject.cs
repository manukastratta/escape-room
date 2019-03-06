using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    public GameObject Teleporter;
    public GameObject groundCylinder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Enabled()
    {
        GameObject handCylinder = GameObject.Find("HandCylinder");
        GameObject handTrigger = GameObject.Find("HandTrigger");
        GameObject handButton = GameObject.Find("HandButton");
        handCylinder.GetComponent<MeshRenderer>().enabled = true;
        handTrigger.GetComponent<MeshRenderer>().enabled = true;
        handButton.GetComponent<MeshRenderer>().enabled = true;
        Teleporter.SetActive(true);
        groundCylinder.SetActive(false);
    }
}
