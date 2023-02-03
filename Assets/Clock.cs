using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;
    private float timer;
    private int hour = 6;
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

        if (timer >= 10)
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
}
