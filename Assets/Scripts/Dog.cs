using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject hungerBar;
    [SerializeField] GameObject hygieneBar;
    [SerializeField] GameObject totalHappinessBar;
    [SerializeField] GameObject taskPanel;
    [SerializeField] Image panelImage;
    [SerializeField] Sprite dogImage;

    public Toy equippedToy = null;
    public float hunger = 50f;
    public float hygiene = 100f;
    public float totalHappiness = 100f;
    public float happiness = 30f;
    public bool selected = false;

    private float secToMinRatio;
    private float barMaxScaleY;
    private float barMaxScaleX;
    private float barMaxScaleZ;
    private Vector3 hungerBarPos;
    private Vector3 hygieneBarPos;
    private Vector3 totalHappinessBarPos;
    private float barHalfLength = 288f;
    private float timer;
    private Clock clock;

    // Start is called before the first frame update
    void Start()
    {
        barMaxScaleZ = hungerBar.transform.localScale.z;
        barMaxScaleX = hungerBar.transform.localScale.x;
        barMaxScaleY = hungerBar.transform.localScale.y;
        hungerBarPos = hungerBar.transform.localPosition;
        hygieneBarPos = hygieneBar.transform.localPosition;
        totalHappinessBarPos = totalHappinessBar.transform.localPosition;

        clock = FindObjectOfType<Clock>();
        secToMinRatio = clock.irlSecToGameMinRatio;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (selected)
        {
            updateMeters();
        }

    }

    // Show dog info panel when mouse CLICKS dog
    private void OnMouseDown()
    {
        Dog[] dogs = FindObjectsOfType<Dog>();
        for (int i = 0; i < dogs.Length; i++)
        {
            dogs[i].selected = false;
            dogs[i].infoPanel.SetActive(false);
            dogs[i].taskPanel.SetActive(false);
        }
        selected = true;

        infoPanel.SetActive(true);
        taskPanel.SetActive(true);
        panelImage.GetComponent<Image>().sprite = dogImage;

        Vector3 dogPos = gameObject.transform.localPosition;
        taskPanel.GetComponent<RectTransform>().position = new Vector3( dogPos.x + 2, dogPos.y + 2, dogPos.z );
    }

    public void closeInfoPanel()
    {
        infoPanel.SetActive(false);
        taskPanel.SetActive(false);
        selected = false;
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
        // hunger is added in Food class
        hygiene -= 5f;
        taskPanel.SetActive(false);
        clock.minute += 5;
    }

    public void giveBath()
    {
        hygiene = 100f;
        happiness -= 15f;
        taskPanel.SetActive(false);
        clock.minute += 20;
    }

    public void giveWalk()
    {
        happiness += 20f;
        hygiene -= 10f;
        hunger -= 15f;
        taskPanel.SetActive(false);
        clock.minute += 20;
    }

    public void giveToy()
    {
        // happiness is added in Toy class
        taskPanel.SetActive(false);
        clock.minute += 5;
    }

}
