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

    private float smallBarMaxScaleY;
    private float longBarMaxScaleY;
    private float barMaxScaleX;
    private float barMaxScaleZ;

    // Start is called before the first frame update
    void Start()
    {
        barMaxScaleZ = happinessBar.transform.localScale.z;
        barMaxScaleX = happinessBar.transform.localScale.x;
        smallBarMaxScaleY = hungerBar.transform.localScale.y;
        longBarMaxScaleY = happinessBar.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        hungerBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (hunger / 100f) * smallBarMaxScaleY, barMaxScaleZ);
        hygieneBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (hygiene / 100f) * smallBarMaxScaleY, barMaxScaleZ);
        happinessBar.gameObject.transform.localScale = new Vector3(barMaxScaleX, (happiness / 100f) * longBarMaxScaleY, barMaxScaleZ);
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
