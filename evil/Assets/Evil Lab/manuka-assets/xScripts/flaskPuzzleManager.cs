using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskPuzzleManager : MonoBehaviour
{
    public static flaskPuzzleManager Instance;

    public bool gameOver = false;
    public bool isVictory = false;
    public bool challengeIsOver = false;

    public int numFlasksBroken = 0;
    public int numFlasksDestroyed = 0;
    public int numTriesLeft = 3;
    public int maxLives = 5;
    public int targetGoal = 15;
    public float dirSpeed = 0.7f;

    List<GameObject> flasksList = new List<GameObject>();

    [SerializeField]
    public Transform startOverTxtTransform;
    [SerializeField]
    public GameObject startOverTxt;

    [SerializeField]
    public Transform centralTxtTransform;
    [SerializeField]
    public GameObject successTxt;

    [SerializeField]
    public Transform sphereKeyTransform;
    [SerializeField]
    public GameObject sphereKey;


    public void Awake()
    {
        Instance = this;
    }

    public void flaskBroken(GameObject brokenFlask)
    {
        numFlasksBroken++;
        Debug.Log(numFlasksBroken);
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
        if (numFlasksDestroyed >= targetGoal && !gameOver)
        {
            isVictory = true;
            gameOver = true;
            endRound();
            StartCoroutine(displayVictoryMessage());
           
        }

        if (numFlasksBroken > maxLives && !gameOver)
        {
            endRound();

            if (numTriesLeft>0)
            {
                Instantiate(startOverTxt, startOverTxtTransform.position, startOverTxtTransform.rotation);
                startOverTxt.SetActive(true);
            }
            else
            {
                challengeIsOver = true; // LOSS, PLAYER DIES
            }
        }
    }

    private void endRound()
    {
        gameOver = true;
        Debug.Log("GAME OVER");
        foreach (GameObject flask in flasksList)
        {
            flask.SetActive(false);
        }
        flasksList.Clear(); // remove flasks from game
        moveFlasksS.Instance.stopGame();
    }

    IEnumerator displayVictoryMessage()
    {
        moveFlasksS.Instance.stopGame();
        GameObject centralTxt = Instantiate(successTxt, centralTxtTransform.position, centralTxtTransform.rotation);
        yield return new WaitForSeconds(2);
        //centralTxt.SetActive(false);
        Destroy(centralTxt.gameObject);

        GameObject sphereKeyObj = Instantiate(sphereKey, sphereKeyTransform.position, sphereKeyTransform.rotation);

        challengeIsOver = true; // VICTORY
        StopCoroutine(displayVictoryMessage());
    }
    
}
