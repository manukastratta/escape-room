using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_control : MonoBehaviour
{
    [SerializeField]
    public Vector3 scale1;

    [SerializeField]
    public Vector3 location;

    // Start is called before the first frame update
    public void shrink()
    {
        transform.localScale = scale1;
    }
}
