using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskTriggerS : MonoBehaviour
{

    [SerializeField]
    private AudioClip glassAudio;
    private AudioSource audioSource;

   //bool isPuzzleOver = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(glassAudio);
        Destroy(other.gameObject);
        flaskPuzzleManager.Instance.flaskBroken(other.gameObject);
    }

    private void Update()
    {
        //if(numFlasksBroken>=5)
        //{
        //    isPuzzleOver = true;
        //}
    }
}