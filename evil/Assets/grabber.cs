using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabber : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveDir;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.Translate(moveDir * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
