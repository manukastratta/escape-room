using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using RHL.Scripts.Model;
using RHL.Scripts.InputSystem;

using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;
using Settings = UnityEngine.XR.XRSettings;

public class BoxInstantiator : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("CenterEyeAnchor");
        GameObject cylinder = GameObject.Find("HandCylinder");
        int layerMask = 1 << 4;
        RaycastHit hit;
        if (Physics.Raycast(transform.position,-Vector3.forward,out hit, Mathf.Infinity, layerMask))
        {
            if (cylinder.GetComponent<Renderer>().enabled == true)
            {
                if (Input.GetButtonDown("Oculus_CrossPlatform_PrimaryThumbstick"))
                {
                    Instantiate(cubePrefab, hit.point + Vector3.forward * 0.25f, Quaternion.identity);
                }
            }
        }
    }
}
