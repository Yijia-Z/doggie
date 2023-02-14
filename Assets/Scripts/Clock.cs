using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;
    public float speedUpMultiplier = 2.0f;
    public float irlSecToGameMinRatio = 5.0f;
    private float timer;
    private int hour = 8;
    private int minute = 0;
    private bool isAM = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= irlSecToGameMinRatio)
        {
            timer = 0;
            minute++;
            if (minute == 60)
            {
                minute = 0;
                hour++;
                if (hour == 13)
                {
                    hour = 1;
                    isAM = false;
                }
            }
        }

        clockText.text = hour.ToString() + ":";
        if (minute < 10)
        {
            clockText.text = clockText.text + "0" + minute.ToString() + " ";
        }
        else
        {
            clockText.text = clockText.text + minute.ToString() + " ";
        }
        if (isAM)
        {
            clockText.text = clockText.text + "AM";
        }
        else
        {
            clockText.text = clockText.text + "PM";
        }
    }
    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = speedUpMultiplier;
    }
}
