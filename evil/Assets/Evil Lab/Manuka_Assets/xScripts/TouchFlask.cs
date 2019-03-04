using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFlask : MonoBehaviour
{

    public challengeS startChallenge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wFlaskT"
       || other.gameObject.tag == "gFlaskT"
           || other.gameObject.tag == "bFlaskT")
        {
            startChallenge.AddUserPattern(other.gameObject);

        }
    }
}
