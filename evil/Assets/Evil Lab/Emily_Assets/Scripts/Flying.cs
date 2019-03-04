using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{

    public bool flying = false;
    public Transform flyTowards;
    private bool reachedCollider;
    private bool reachedFinalDestination;
    public Transform finalDestination;


    // Update is called once per frame
    void Update()
    {
        if (flying)
        {
            if (!reachedCollider)
            {
                transform.position = Vector3.MoveTowards(transform.position, flyTowards.position, 0.2f * Time.deltaTime);

            }

            if ((transform.position - flyTowards.position).magnitude < 0.01f)
            {
                reachedCollider = true;
                print("reached collider!!! woooooo");
            }
            if(reachedCollider)
            {
                transform.position = Vector3.MoveTowards(transform.position, finalDestination.position, 0.2f * Time.deltaTime);

            }
            if (!reachedFinalDestination && (transform.position - finalDestination.position).magnitude < 0.01f)
            {
                reachedFinalDestination = true;
                GameObject.Find("Door").GetComponent<DoorScript>().shapesNum += 1.0f;

                print("reached final destination!!! yaya");
            }

        }

    }
}
