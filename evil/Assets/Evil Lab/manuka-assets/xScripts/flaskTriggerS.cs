using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskTriggerS : MonoBehaviour
{

    [SerializeField]
    private AudioClip glassAudio;
    private AudioSource audioSource;
    
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

}