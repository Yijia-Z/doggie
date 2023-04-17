using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;
    public GameObject BlackPanel;
    public float speedUpMultiplier = 2.0f;
    public float irlSecToGameMinRatio = 5.0f;
    private float timer;
    public int hour = 8;
    public int minute = 0;
    private bool isAM = true;
    public int day = 1;
    private bool isPaused = false;
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeBlackOut(false));
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
                StartCoroutine(fadeBlack());
                isAM = true;
                hour = 8;
                minute = 0;
                day++;

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

    public IEnumerator FadeBlackOut(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = BlackPanel.GetComponent<Image>().color;
        float fadeAmount;
        while (isFading)
        {
            yield return new WaitForSecondsRealtime(1);
        }

        if (fadeToBlack)
        {
            while (BlackPanel.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                BlackPanel.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (BlackPanel.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                BlackPanel.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }

        BlackPanel.SetActive(false);
    }

    public IEnumerator fadeBlack()
    {
        isFading = true;
        BlackPanel.SetActive(true);
        Color objectColor = BlackPanel.GetComponent<Image>().color;
        float fadeAmount;

        while (BlackPanel.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (1 * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            BlackPanel.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2);
        isFading = false;

        ownerCheck();

        isAM = true;
        hour = 8;
        minute = 0;
        StartCoroutine(FadeBlackOut(false));
        
    }

    private void ownerCheck()
    {
        // Select the next available owner
        int ownerIndex = -1;
        bool ownerAvailable = false;
        Dog[] dogs = FindObjectsOfType<Dog>();
        for (int i = 0; i < dogs.Length; i++)
        {
            if (DatingProgress.IsOwnerAvailable(i))
            {
                ownerAvailable = true;
            }
            if (dogs[i].getHappiness() >= 80 && DatingProgress.IsOwnerAvailable(i))
            {
                ownerIndex = dogs[i].getOwnerIndex();
            }
        }
        if (!ownerAvailable)
        {
            // switch to alone ending scene
            SceneManager.LoadScene(20); // 

        }
        else if (ownerIndex == -1)
        {
            Debug.LogError("No available owners found!");
        }
        else
        {

            // Save the selected owner and load the corresponding scene
            DatingProgress.MarkOwnerAsUnavailable(ownerIndex);
            DatingProgress.SaveProgress(ownerIndex, 1);
            //load scenes
            if (ownerIndex == 0)
                SceneManager.LoadScene(15); // LoganAskOut
            else if (ownerIndex == 1)
                SceneManager.LoadScene(16); // ElaineAskOut
            else if (ownerIndex == 2)
                SceneManager.LoadScene(17); // JeffAskOut

        }
    }
}
