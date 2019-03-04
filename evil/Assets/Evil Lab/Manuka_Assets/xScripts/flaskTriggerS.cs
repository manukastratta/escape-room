using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskTriggerS : MonoBehaviour
{
    //[SerializeField]
    //private GameObject flask;

    [SerializeField]
    private AudioClip glassAudio;
    private AudioSource audioSource;

    //int numFlasksBroken = 0;
    bool isPuzzleOver = false;

    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(glassAudio);

        Destroy(other.gameObject);
        //flaskPuzzleManager.Instance.counter++
        flaskPuzzleManager.Instance.flaskBroken(other.gameObject);
        //numFlasksBroken++;
        //Debug.Log("FLASK BROKEN");
        //Debug.Log(numFlasksBroken);
        //other.gameObject.SetActive(false);
    }

    private void Update()
    {
        //if(numFlasksBroken>=5)
        //{
        //    isPuzzleOver = true;
        //}
    }
}