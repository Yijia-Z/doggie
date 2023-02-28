using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsPanel : MonoBehaviour
{
    Dog dog;

    //for selecting dog w/ mouse
    private Camera _camera;
    private Renderer _renderer;
    private Ray ray;
    private RaycastHit hit;

    //for dog stats
    string dogName = "";
    public Image dogImage;
    float dogHunger;
    float dogHygiene;
    float dogHappiness;
    int maxHealth = 100;
    public TextMeshProUGUI dogNameTxt;

    //public Image ProgressImage;
    public Slider_ hungerSlider;
    public Slider_ hygieneSlider;
    public Slider_ happinessSlider;

    // Start is called before the first frame update
    void Start()
    {
        dog = null;
        _camera = Camera.main;
        _renderer = GetComponent<Renderer>();

        hungerSlider = GetComponent<Slider_>();
        hygieneSlider = GetComponent<Slider_>();
        happinessSlider = GetComponent<Slider_>();

        dogImage = GetComponent<Image>();
        dogNameTxt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Select entity    
                if (hit.transform.tag == "Dog")
                {
                    //set dog to currently selected dog gameobject
                    dog = hit.transform.gameObject.GetComponent(typeof(Dog)) as Dog;

                    //Get & set dog info

                    dogName = dog.getName();
                    dogNameTxt.text = dogName;

                    dogHunger = dog.getHunger();
                    hungerSlider.setSlider("Hunger", dogHunger, maxHealth);

                    dogHygiene = dog.getHygiene();
                    hygieneSlider.setSlider("Hygiene", dogHygiene, maxHealth);

                    dogHappiness = dog.getHappiness();
                    happinessSlider.setSlider("Happiness", dogHappiness, maxHealth);

                    //dogImage.GetComponent<SpriteRenderer>().sprite = dog.getSprite();
                   


                  
                }
            }
        }
    }
}
