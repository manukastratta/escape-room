using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManagerS : MonoBehaviour
{

    bool isGameOver = false;
    bool isVictory = false;
    bool puzzleOneCompleted = false;
    bool puzzleTwoCompleted = false;
    bool puzzleThreeCompleted = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleOneCompleted && puzzleTwoCompleted && puzzleThreeCompleted)
        {
            isGameOver = true;
            isVictory = true;
        }

        // if timer is over and games aren't all won, then game is over
        // isVictory = false
        // isGameOver = true;

    }
}
