using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaler1 : MonoBehaviour
{
    Vector3 scale2;

    GameObject DpadScaler;
    robot_control playerScript;

    // Start is called before the first frame update
    void Start()
    {
        DpadScaler = GameObject.Find("Robot");
        playerScript = DpadScaler.GetComponent<robot_control>();
    }

    // Update is called once per frame
    void Update()
    {
        scale2 = playerScript.scale1;
        transform.localScale = scale2;
    }
}