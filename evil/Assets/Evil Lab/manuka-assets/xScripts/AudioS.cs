using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioS : MonoBehaviour
{


    public AudioClip Sound;
    private AudioSource audioSource;
    bool isPlaying;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        audioSource.loop = true;
        audioSource.Play();



    }

    /*public void PlaySound()
    {
        Debug.Log("clicked");
        audioSource.Play();
    }
    */


   /*private void OnTriggerEnter(Collider colliderObj)
    {
        if (colliderObj.gameObject.tag == "bFlaskT"
        || colliderObj.gameObject.tag == "wFlaskT"
            || colliderObj.gameObject.tag == "gFlaskT")
        {
            Debug.Log("clicked on one of the flasks");
            audioSource.Play();
        }
        //audioSource.loop = true;

    }
    */   

    //private void OnTriggerExit(Collider other)
    //{

    //    audioSource.Stop();
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
