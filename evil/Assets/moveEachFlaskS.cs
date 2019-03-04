using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEachFlaskS : MonoBehaviour
{
    //public float speed = 1.0f;
    //private Rigidbody rb;
    float speed = 0.1f;
    Vector3 moveDir = new Vector3(0, -1, 0);

    void Update()
    {
        transform.Translate(moveDir * speed);
    }
}
