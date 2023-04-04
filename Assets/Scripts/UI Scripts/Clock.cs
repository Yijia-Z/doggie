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
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        // Update in-game time
        timer += Time.deltaTime;

        if (timer >= irlSecToGameMinRatio)
        {
            timer = 0;
            minute++;
        }
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

                // Select the next available owner
                int ownerIndex = -1;
                Dog[] dogs = FindObjectsOfType<Dog>();
                string dogName;
                for (int i = 0; i < dogs.Length; i++)
                {
                    if (dogs[i].getHappiness() >= 100)
                    {
                        ownerIndex = dogs[i].getOwnerIndex();
                    }
                    if (DatingProgress.IsOwnerAvailable(ownerIndex))
                    {
                    }
                }
                if (ownerIndex == -1)
                {
                    Debug.LogError("No available owners found!");
                }
                else
                {
                    // Save the selected owner and load the corresponding scene
                    DatingProgress.MarkOwnerAsUnavailable(ownerIndex);
                    DatingProgress.SaveProgress(ownerIndex, 1);
                    //SceneManager.LoadScene();
                }
            }
        }

        // Update clock text displayed
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
        isPaused = true;
        Time.timeScale = 0f;
        // Save current time
        /*
        PlayerPrefs.SetInt("savedHour", hour);
        PlayerPrefs.SetInt("savedMinute", minute);
        PlayerPrefs.SetInt("savedDay", day);
        PlayerPrefs.SetInt("isAM", isAM ? 1 : 0);
        PlayerPrefs.Save();
        */
    }

    public bool getIsPaused()
    {
        return isPaused;
    }
    public void ResumeTime()
    {
        isPaused = false;
        Time.timeScale = 1f;
        // Load saved time
        /*
        if (PlayerPrefs.HasKey("savedHour"))
        {
            hour = PlayerPrefs.GetInt("savedHour");
            minute = PlayerPrefs.GetInt("savedMinute");
            day = PlayerPrefs.GetInt("savedDay");
            isAM = PlayerPrefs.GetInt("isAM") == 1 ? true : false;
        }
        */
    }

    public void SpeedUpTime()
    {
        if (!isPaused)
        {
            Time.timeScale = Time.timeScale * speedUpMultiplier;
        }
    }
}
