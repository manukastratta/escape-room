using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskPuzzleManager : MonoBehaviour
{
    public bool gameOver = false; 

    public static flaskPuzzleManager Instance;

    public int numFlasksBroken = 0;
    public int numFlasksDestroyed = 0;
    List<GameObject> flasksList = new List<GameObject>();


    public void Awake()
    {
       Instance = this;
    }

    public void flaskBroken(GameObject brokenFlask) {
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

    private void Update() {
        if(numFlasksBroken >=5 && !gameOver) {
            gameOver = true;
            Debug.Log("GAME OVER");
            foreach (GameObject flask in flasksList)
            {
                flask.SetActive(false);
            }
            flasksList.Clear(); // MAKE THEM INACTIVE
        }
        Debug.Log("num flasks destroyed" + numFlasksDestroyed);
        Debug.Log("num flasks broken" + numFlasksBroken);
    }
}
