using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;
    public float speedUpMultiplier = 2.0f;
    public float irlSecToGameMinRatio = 5.0f;
    private float timer;
    public int hour = 8;
    public int minute = 0;
    private bool isAM = true;
    public int day = 1;

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
            if (minute >= 60)
            {
                minute = minute - 60;
                hour++;
                if (hour == 12)
                {
                    isAM = false;
                }
                if (hour == 13 && !isAM)
                {
                    hour = 1;
                }
                else if (hour == 6 && !isAM)
                {
                    isAM = true;
                    hour = 8;
                    minute = 0;
                    day++;
                    SceneManager.LoadScene(4);
                }
            }
        }

        if (day % 5 == 1)
        {
            clockText.text = "Monday\n";
        }
        else if (day % 5 == 2)
        {
            clockText.text = "Tuesday\n";
        }
        else if (day % 5 == 3)
        {
            clockText.text = "Wednesday\n";
        }
        else if (day % 5 == 4)
        {
            clockText.text = "Thursday\n";
        }
        else if (day % 5 == 0)
        {
            clockText.text = "Friday\n";
        }


        clockText.text += hour.ToString() + ":";
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
