using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFlasksS : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnees;

    [SerializeField]
    public Transform spawnPosW;
    [SerializeField]
    public Transform spawnPosG;
    [SerializeField]
    public Transform spawnPosB;

    private void Start()
    {
        //Vector3 initialPos = wSmallFlask.transform.position;

        //oriX = initialPos[0];
        //oriY = initialPos[1];
        //oriZ = initialPos[2];

        StartCoroutine(spawnNewFlask());
    }

    /*
     * Instantiates either a white, gray or black falling flask
     * every 2 seconds.    
     */ 
    IEnumerator spawnNewFlask()
    {
        while (!flaskPuzzleManager.Instance.gameOver && flaskPuzzleManager.Instance.numFlasksBroken < 5)
        {
            yield return new WaitForSeconds(2);
            if(flaskPuzzleManager.Instance.numFlasksBroken < 5)
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
            }

        }

    }


    void Update()
    {
    
        //if(Input.GetMouseButton(0)) // on click
        //{
        //    spawnNewFlask();
        //}
    }


}
