using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float TimeLeft;
    public Text timerTxt;
    public PlayerMovement pm;

    private float originalTime;
    
    // Start is called before the first frame update
    void Start()
    {
        originalTime = TimeLeft;
    }

    // Update is called once per frame
    void Update()
    { 
            if(TimeLeft >= -1)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                pm.RNG();
                TimeLeft = originalTime;
            }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = (int)Math.Floor(currentTime / 60);
        float seconds = (int)Math.Floor(currentTime % 60);



        timerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
