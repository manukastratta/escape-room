using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFlasksS : MonoBehaviour
{
    public static moveFlasksS Instance;
    public float numSeconds = 2;

    [SerializeField]
    public GameObject[] spawnees;

    [SerializeField]
    public Transform spawnPosW;
    [SerializeField]
    public Transform spawnPosG;
    [SerializeField]
    public Transform spawnPosB;


    public void startGame()
    {
        StartCoroutine(spawnNewFlask());
    }

    public void stopGame()
    {
        StopCoroutine(spawnNewFlask());
        flaskPuzzleManager.Instance.gameOver = true;
    }

    public void Awake()
    {
        Instance = this;
    }

    /*
     * Instantiates either a white, gray or black falling flask
     * every 2 seconds.    
     */
    IEnumerator spawnNewFlask()
    {

        while (!flaskPuzzleManager.Instance.gameOver && 
        flaskPuzzleManager.Instance.numFlasksBroken <= flaskPuzzleManager.Instance.maxLives)
        {
            yield return new WaitForSeconds(numSeconds);
            if (!flaskPuzzleManager.Instance.gameOver &&
            flaskPuzzleManager.Instance.numFlasksBroken <= flaskPuzzleManager.Instance.maxLives)
            {
                GameObject element;
                int randomNum = Random.Range(0, 3);

                if (randomNum == 0)
                {
                    element = Instantiate(spawnees[0], spawnPosW.position, spawnPosW.rotation);
                }
                else if (randomNum == 1)
                {
                    element = Instantiate(spawnees[1], spawnPosG.position, spawnPosG.rotation);
                }
                else
                {
                    element = Instantiate(spawnees[2], spawnPosB.position, spawnPosB.rotation);

                }
                flaskPuzzleManager.Instance.addFlaskToList(element);
                if (numSeconds >= 0.4f) // cannot go lower than 0.5 seconds
                {
                    //Debug.Log("incrementing speed");
                    numSeconds -= 0.05f;
                    flaskPuzzleManager.Instance.dirSpeed += 0.01f;
                    //moveEachFlaskS.Instance.incrementDirSpeed();
                }
            }

        }

    }

    //public void resetCreationSpeed()
    //{
    //    numSeconds = 2;
    //    //moveEachFlaskS.Instance.speed = 0.1f;
    //}


    //if(Input.GetMouseButton(0)) // on click
    //{
    //    spawnNewFlask();
    //}
}
