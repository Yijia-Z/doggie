using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject hungerBar;
    [SerializeField] GameObject hygieneBar;
    [SerializeField] GameObject happinessBar;

    public float hunger = 50f;
    public float hygiene = 100f;
    public float happiness = 100f;

    private float barMaxScaleY;
    private float barMaxScaleX;
    private float barMaxScaleZ;
    private Vector3 hungerBarPos;
    private Vector3 hygieneBarPos;
    private Vector3 happinessBarPos;

    // Start is called before the first frame update
    void Start()
    {
        barMaxScaleZ = hungerBar.transform.localScale.z;
        barMaxScaleX = hungerBar.transform.localScale.x;
        barMaxScaleY = hungerBar.transform.localScale.y;
        hungerBarPos = hungerBar.transform.localPosition;
        hygieneBarPos = hygieneBar.transform.localPosition;
        happinessBarPos = happinessBar.transform.localPosition;
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
        if (happiness > 100f)
        {
            happiness = 100f;
        }
        hungerBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (hunger / 100f) * barMaxScaleY, barMaxScaleZ);
        hungerBar.gameObject.transform.localPosition = new Vector3(hungerBarPos.x + ((1-(hunger/100f)) * -288), hungerBarPos.y, hungerBarPos.y);
        hygieneBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (hygiene / 100f) * barMaxScaleY, barMaxScaleZ);
        hygieneBar.gameObject.transform.localPosition = new Vector3(hygieneBarPos.x + ((1 - (hygiene / 100f)) * -288), hygieneBarPos.y, hygieneBarPos.y);
        happinessBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (happiness / 100f) * barMaxScaleY, barMaxScaleZ);
        happinessBar.gameObject.transform.localPosition = new Vector3(happinessBarPos.x + ((1 - (happiness / 100f)) * -288), happinessBarPos.y, happinessBarPos.y);
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

    /* Show dog info panel when mouse is HOVERING OVER dog

    private void OnMouseOver()
    {
        infoPanel.SetActive(true);
    }
    
    private void OnMouseExit()
    {
        infoPanel.SetActive(false);
    }

    */
}
