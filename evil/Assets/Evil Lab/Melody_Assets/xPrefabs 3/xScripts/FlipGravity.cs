using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour
{

    public GameObject doorName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (doorName.GetComponent<DoorScript>().shapesNum >= 2.0f)
        {
            Debug.Log("Two?");
            Physics.gravity = new Vector3(0, 1.0f, 0);
            GameObject player = GameObject.Find("RHLGoCameraRig");
            DelayedFlip();
            Invoke("DelayedFlip", 100f);
        }

        Physics.gravity = new Vector3(0, -1.0f, 0);
    }


    void DelayedFlip()
    {
        GameObject player = GameObject.Find("RHLGoCameraRig");
        if (player != null)
        {
            StartCoroutine(RotateImage(player));
        }


    }

    IEnumerator RotateImage(GameObject player)
    {
        float moveSpeed = 0.00007f;
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
