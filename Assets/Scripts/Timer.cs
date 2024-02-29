using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float currentTime;
    private bool isTiming;


    public void StartTimer()
    {
        isTiming = true;

    }

    public void StopTimer()
    {
        isTiming = false;
        print("timer stopped");


    }

    public float GetTime()
    {
        return currentTime;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (isTiming == true)
        { 
        currentTime += Time.deltaTime;
    }
        
    }
}
