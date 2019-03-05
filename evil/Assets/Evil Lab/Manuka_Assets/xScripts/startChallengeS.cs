using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startChallengeS : MonoBehaviour
{

    public void startChallenge(GameObject textField)
    {
        Debug.Log("starting challenge");
        flaskPuzzleManager.Instance.gameOver = false;
        flaskPuzzleManager.Instance.numFlasksBroken = 0;
        flaskPuzzleManager.Instance.numFlasksDestroyed = 0;
        textField.SetActive(false);
        flaskPuzzleManager.Instance.numTriesLeft--;
        if (flaskPuzzleManager.Instance.numTriesLeft > -1)
        {
            moveFlasksS.Instance.resetValues(); // speed of creation and velocity
            moveFlasksS.Instance.startGame(); // start game again
        }

    }

}
