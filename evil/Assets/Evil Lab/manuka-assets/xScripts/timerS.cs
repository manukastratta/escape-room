using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//public class timerS : MonoBehaviour

//{ 
//    public Text timerText;
//    private float mainTimer;
//    private float timer;
//    private bool canCount = true;
//    private bool doOnce = false;

//    private void Start()
//    {
//        mainTimer = 60; // 60 seconds
//        timer = mainTimer;
//    }

//    private void Update()
//    {
//        if(timer >= 0.0f && canCount)
//        {
//            timer -= Time.deltaTime;
//            timerText.text = timer.ToString("f");
//        } else if(timer<=0.0 && !doOnce)
//        {
//            canCount = false;
//            doOnce = true;
//            timerText.text = "0.00";
//            timer = 0.0f;
//        }
//    }

//}


/* CODE FOR A TIMER, NOT A COUNTDOWN */
public class timerS : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    // Start is called before the first frame update

    
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }
}



