using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private Animator _animator;
    public float shapesNum = 0.0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (shapesNum >= 3.0f)
        {
            _animator.SetBool("open", true);
        }
    }
}



