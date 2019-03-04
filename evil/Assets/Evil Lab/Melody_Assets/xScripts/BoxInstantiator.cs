using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        int layerMask = 1 << 4;
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.forward,out hit, Mathf.Infinity, layerMask))
        {
            if (Input.GetButtonDown("Oculus_CrossPlatform_PrimaryHandTrigger")) { 
            Instantiate(cubePrefab, transform.position + hit.point-Vector3.forward, Quaternion.identity);
            }
        }
    }
}
