using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challengeS : MonoBehaviour
{
    bool isCubeActive = true;

    //AudioSource clip1 = (AudioSource)Resources.Load("xSounds/low.wav");

    public GameObject testCube;
    public GameObject wFlask;
    public GameObject gFlask;
    public GameObject bFlask;

    List<GameObject> patternOne = new List<GameObject>();
    List<GameObject> patternTwo = new List<GameObject>();
    List<GameObject> patternThree = new List<GameObject>();


    List<GameObject> userPattern = new List<GameObject>();


    public void Start()
    {
        setUpPatterns();

    }

    public void playThisGame()
    {
        StartCoroutine(displayPatternOne());
        displayPatternOne();

        /*
        // how to wait for pattern 2 to start?
        StartCoroutine(displayPatternTwo());
        displayPatternTwo();

        StartCoroutine(displayPatternThree());
        displayPatternThree(); */
    }

    private void setUpPatterns()
    {
        Debug.Log("patterns set up");
        patternOne.Add(wFlask);
        patternOne.Add(gFlask);
        patternOne.Add(bFlask);
        patternOne.Add(gFlask);
        patternOne.Add(wFlask);

        patternTwo.Add(wFlask);
        patternTwo.Add(bFlask);
        patternTwo.Add(wFlask);
        patternTwo.Add(gFlask);
        patternTwo.Add(bFlask);
        patternTwo.Add(bFlask);
        patternTwo.Add(gFlask);

        patternThree.Add(wFlask);
        patternThree.Add(bFlask);
        patternThree.Add(gFlask);
        patternThree.Add(bFlask);
        patternThree.Add(wFlask);
        patternThree.Add(gFlask);
        patternThree.Add(bFlask);
        patternThree.Add(wFlask);
        patternThree.Add(gFlask);
        patternThree.Add(gFlask);
        patternThree.Add(bFlask);
        patternThree.Add(gFlask);
        patternThree.Add(wFlask);

    }

    public IEnumerator displayPatternOne()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("pattern1 display starting");
        foreach (GameObject obj in patternOne)
        {
            obj.SetActive(true);
            //clip1.Play(); // not playing...
            yield return new WaitForSeconds(1);
            obj.SetActive(false);
        }    
    }

    public bool checkIfCorrectPattern(List<GameObject> pattern)
    {
        for(int i = 0; i<pattern.Count; i++)
        {
            if (pattern[i] != userPattern[i])
            {
                return false; // mismatch between given and input pattern
            }
        }

        return true; // if no issues by end of pattern, return true

        //int counter = 0;
        //foreach (GameObject obj in pattern) 

    }

    // how to call this function? when?
    public void OnTriggerEnter(Collider colliderObj)
    {
        userPattern.Add(colliderObj.gameObject);
        Debug.Log("something added to userPattern list");

        if (colliderObj.gameObject.tag == "wFlaskT"
        || colliderObj.gameObject.tag == "gFlaskT"
            || colliderObj.gameObject.tag == "bFlaskT")
        {
            userPattern.Add(colliderObj.gameObject);
            Debug.Log("something added to userPattern list");
        }
    }

    public void AddUserPattern(GameObject toAdd)
    {
        userPattern.Add(toAdd);
    }


    public IEnumerator displayPatternTwo()
    {
        yield return new WaitForSeconds(0.8f);
        Debug.Log("pattern2 display starting");
        foreach (GameObject obj in patternTwo)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            obj.SetActive(false);
        }

    }

    public IEnumerator displayPatternThree()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("pattern3 display starting");
        foreach (GameObject obj in patternThree)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            obj.SetActive(false);
        }

    }

    /*private void flaskDisplay(GameObject firstOn, GameObject secondOff, GameObject thirdOff)
    {
        firstOn.SetActive(true);
        secondOff.SetActive(false);
        thirdOff.SetActive(false);
    }
    */


}
