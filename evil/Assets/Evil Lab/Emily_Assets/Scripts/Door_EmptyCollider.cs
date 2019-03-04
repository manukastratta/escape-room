using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_EmptyCollider : MonoBehaviour
{
    public string keyShapeName;
    private bool touchedOnce;

    void OnTriggerEnter (Collider target)
    {
        if (target.gameObject.name == keyShapeName)
            {
            if (touchedOnce == false)
            {
                touchedOnce = true;
                GameObject.Find(keyShapeName).GetComponent<Flying>().flying = true;
                GameObject.Find(keyShapeName).GetComponent<Flying>().flyTowards = transform;
            }
        }

    }
}


