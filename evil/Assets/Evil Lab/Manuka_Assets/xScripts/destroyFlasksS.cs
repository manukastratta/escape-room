using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFlasksS : MonoBehaviour
{

    [SerializeField]
    private AudioClip wSoundAudio;
    private AudioSource wAudioSource;

    [SerializeField]
    private AudioClip gSoundAudio;
    private AudioSource gAudioSource;

    [SerializeField]
    private AudioClip bSoundAudio;
    private AudioSource bAudioSource;

    void Start()
    {
        wAudioSource = GetComponent<AudioSource>();
        gAudioSource = GetComponent<AudioSource>();
        bAudioSource = GetComponent<AudioSource>();
    }

    public void setInactiveWhite(GameObject obj)
    {
        int counter = 0;
        wAudioSource.PlayOneShot(wSoundAudio);
        //GetComponent(MeshRenderer).enabled = false;
        while (true)
        {
            if(counter>=100*1000000)
            {
                Destroy(this.gameObject);
                break;
            }
            counter++;
        }
        this.gameObject.SetActive(false);
        flaskPuzzleManager.Instance.removeFlaskFromList(this.gameObject);
        flaskPuzzleManager.Instance.numFlasksDestroyed++;
    }

    public void setInactiveGray(GameObject obj)
    {
        int counter = 0;
        gAudioSource.PlayOneShot(gSoundAudio);
        //GetComponent(MeshRenderer).enabled = false;
        while (true)
        {
            if (counter >= 100 * 1000000)
            {
                Destroy(this.gameObject);
                break;
            }
            counter++;
        }
        this.gameObject.SetActive(false);
        flaskPuzzleManager.Instance.removeFlaskFromList(this.gameObject);
        flaskPuzzleManager.Instance.numFlasksDestroyed++;
    }

    public void setInactiveBlack(GameObject obj)
    {
        int counter = 0;
        bAudioSource.PlayOneShot(bSoundAudio);
        //GetComponent(MeshRenderer).enabled = false;
        while (true)
        {
            if (counter >= 100 * 1000000)
            {
                Destroy(this.gameObject);
                break;
            }
            counter++;
        }
        this.gameObject.SetActive(false);
        flaskPuzzleManager.Instance.removeFlaskFromList(this.gameObject);
        flaskPuzzleManager.Instance.numFlasksDestroyed++;
    }

    //public void destroyWhiteFlask()
    //{
    //    wAudioSource.PlayOneShot(wSoundAudio);
    //}

    //public void destroyGrayFlask()
    //{
    //    gAudioSource.PlayOneShot(gSoundAudio);
    //}

    //public void destroyBlackFlask()
    //{
    //    bAudioSource.PlayOneShot(bSoundAudio);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    audioSource.PlayOneShot(glassAudio);

    //    Destroy(other.gameObject);
    //    //other.gameObject.SetActive(false);
    //}
    //public void OnTriggerEnter(Collider other)
    //{
    //    //currFlask.SetActive(false);
    //}


}
