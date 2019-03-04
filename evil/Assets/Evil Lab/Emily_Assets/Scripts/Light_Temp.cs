using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Temp : MonoBehaviour
{
    public float speed = 2f;
    public Color startColor;
    public Color endColor;
    public bool repeatable = false;
    float startTime;

    Light lt;

    void Start()
    {
        startTime = Time.time;
        lt = GetComponent<Light>();
    }

    void Update()
    { 
        if (!repeatable)
        {
            float t = (Time.time - startTime) * speed;
            lt.color = Color.Lerp(startColor, endColor, t);
            }
    }
}
