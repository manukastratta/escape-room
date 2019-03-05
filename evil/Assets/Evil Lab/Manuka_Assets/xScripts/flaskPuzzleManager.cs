using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskPuzzleManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool isVictory = false;

    public static flaskPuzzleManager Instance;

    public int numFlasksBroken = 0;
    public int numFlasksDestroyed = 0;
    public int numTriesLeft = 3;
    public int maxLives = 3;
    List<GameObject> flasksList = new List<GameObject>();

    [SerializeField]
    public Transform startOverTxtTransform;
    [SerializeField]
    public GameObject startOverTxt;

    public void Awake()
    {
        Instance = this;
    }

    public void flaskBroken(GameObject brokenFlask)
    {
        numFlasksBroken++;
        //Debug.Log(numFlasksBroken);
        removeFlaskFromList(brokenFlask);
    }

    public void removeFlaskFromList(GameObject flaskToRemove)
    {
        flasksList.Remove(flaskToRemove);
    }

    public void addFlaskToList(GameObject flask)
    {
        flasksList.Add(flask);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)) // on click
        {
            Debug.Log("flaks broken: " + numFlasksBroken);
            Debug.Log("tries left: " + numTriesLeft);
        }

        if (numFlasksDestroyed >= 20 && !gameOver)
        {
            isVictory = true;
            gameOver = true;
        }

        if (numFlasksBroken > maxLives && !gameOver)
        {
            gameOver = true;
            Debug.Log("GAME OVER");
            foreach (GameObject flask in flasksList)
            {
                flask.SetActive(false);
            }
            flasksList.Clear(); // MAKE THEM INACTIVE
            if(numTriesLeft>0)
            {
                Instantiate(startOverTxt, startOverTxtTransform.position, startOverTxtTransform.rotation);
                startOverTxt.SetActive(true);
            }
            moveFlasksS.Instance.stopGame();

        }
    }

    //public void startChallenge(GameObject textField)
    //{
    //    Debug.Log("starting challenge");
    //    gameOver = false;
    //    numFlasksBroken = 0;
    //    numFlasksDestroyed = 0;
    //    textField.SetActive(false);
    //    numTriesLeft--;
    //    if (numTriesLeft>-1)
    //    {
    //        moveFlasksS.Instance.resetValues(); // speed of creation and velocity
    //        moveFlasksS.Instance.startGame(); // start game again
    //    }

    //}
}
