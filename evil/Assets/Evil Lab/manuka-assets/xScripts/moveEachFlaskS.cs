using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEachFlaskS : MonoBehaviour
{
    public static moveEachFlaskS Instance;

    public void Awake()
    {
        Instance = this;
    }

    //public float speed = 0.1f;
    Vector3 moveDir = new Vector3(0, -1, 0);

    void Update()
    {
        transform.Translate(moveDir * flaskPuzzleManager.Instance.dirSpeed * Time.deltaTime);
    }

    //public void incrementDirSpeed()
    //{
    //    //Debug.Log("incrementing dir speed");
    //    //speed += 0.025f;
    //    flaskPuzzleManager.Instance.dirSpeed += 0.025f;
    //}

    //public void resetSpeed()
    //{
    //    speed = 0.1f;
    //}

    //public void resetDirSpeed()
    //{
    //    speed = 0.1f;
    //}
}