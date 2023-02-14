using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject hungerBar;
    [SerializeField] GameObject hygieneBar;
    [SerializeField] GameObject totalHappinessBar;

    public float hunger = 50f;
    public float hygiene = 100f;
    public float totalHappiness = 100f;
    public float happiness = 30f;

    private float secToMinRatio;
    private float barMaxScaleY;
    private float barMaxScaleX;
    private float barMaxScaleZ;
    private Vector3 hungerBarPos;
    private Vector3 hygieneBarPos;
    private Vector3 totalHappinessBarPos;
    private float barHalfLength = 288f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        barMaxScaleZ = hungerBar.transform.localScale.z;
        barMaxScaleX = hungerBar.transform.localScale.x;
        barMaxScaleY = hungerBar.transform.localScale.y;
        hungerBarPos = hungerBar.transform.localPosition;
        hygieneBarPos = hygieneBar.transform.localPosition;
        totalHappinessBarPos = totalHappinessBar.transform.localPosition;

        Clock clock = FindObjectOfType<Clock>();
        secToMinRatio = clock.irlSecToGameMinRatio;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hygiene);
        if (hunger > 100f)
        {
            hunger = 100f;
        }
        if (hygiene > 100f)
        {
            hygiene = 100f;
        }
        if (happiness > 30f)
        {
            happiness = 30f;
        }

        timer += Time.deltaTime;
        depreciateTimeStats();
        updatetotalHappiness();
        updateMeters();
    }

    // Show dog info panel when mouse CLICKS dog
    private void OnMouseDown()
    {
        infoPanel.SetActive(true);
    }

    public void closeInfoPanel()
    {
        infoPanel.SetActive(false); ;
    }

    private void updateMeters()
    {
        hungerBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (hunger / 100f) * barMaxScaleY, barMaxScaleZ);
        hungerBar.gameObject.transform.localPosition = new Vector3(hungerBarPos.x + ((1 - (hunger / 100f)) * -barHalfLength), hungerBarPos.y, hungerBarPos.y);
        hygieneBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (hygiene / 100f) * barMaxScaleY, barMaxScaleZ);
        hygieneBar.gameObject.transform.localPosition = new Vector3(hygieneBarPos.x + ((1 - (hygiene / 100f)) * -barHalfLength), hygieneBarPos.y, hygieneBarPos.y);
        totalHappinessBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (totalHappiness / 100f) * barMaxScaleY, barMaxScaleZ);
        totalHappinessBar.gameObject.transform.localPosition = new Vector3(totalHappinessBarPos.x + ((1 - (totalHappiness / 100f)) * -barHalfLength), totalHappinessBarPos.y, totalHappinessBarPos.y);
    }

    private void updatetotalHappiness()
    {
        totalHappiness = ((hunger / 100f) * 40) + ((hygiene / 100f) * 30) + happiness;
        if (totalHappiness > 100f)
        {
            totalHappiness = 100f;
        }
    }

    private void depreciateTimeStats()
    {
        if (timer > secToMinRatio * 6)
        {
            hygiene -= 1;
            hunger -= 2;
            totalHappiness -= 2;
            if (hygiene < 0)
            {
                hygiene = 0;
            }
            if (hunger < 0)
            {
                hunger = 0;
            }
            if (totalHappiness < 0)
            {
                totalHappiness = 0;
            }

            timer = 0;
        }
    }

    public void giveFood()
    {

    }

    public void giveBath()
    {
        hygiene = 100f;

    }

    public void giveWalk()
    {

    }

    public void giveToy()
    {

    }
}
