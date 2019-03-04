using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Door").GetComponent<DoorScript>().shapesNum >= 2.0f)
        {
            Physics.gravity = new Vector3(0, 1.0f, 0);
            GameObject player = GameObject.Find("Player");
            DelayedFlip();
            Invoke("DelayedFlip", 100f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -1.0f, 0);
    }


    void DelayedFlip()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            StartCoroutine(RotateImage());
        }

        IEnumerator RotateImage()
        {
            float moveSpeed = 0.007f;
            float x = 180;
            while (player.transform.rotation.x < 180)
            {
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(180, 0, 0), moveSpeed * Time.time);
                yield return null;
            }
            player.transform.rotation = Quaternion.Euler(180, 0, 0);
            yield return null;
        }
    }
}
