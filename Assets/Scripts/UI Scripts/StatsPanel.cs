using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Numerics;
using System.Diagnostics;

public class StatsPanel : MonoBehaviour
{
    Dog dog = null;

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

    //public Image ProgressImage;
    public TextMeshProUGUI dogNameTxt;
    public Slider_ hungerSlider;
    public Slider_ hygieneSlider;
    public Slider_ happinessSlider;

    // Start is called before the first frame update
    void Start()
    {
        dog = null;
        _camera = Camera.main;
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if click on Dog
        if (Input.GetMouseButtonDown(0))
        {
            //UnityEngine.Debug.Log("Finding doggies");

            Dog[] dogs = FindObjectsOfType<Dog>();
            for (int i = 0; i < dogs.Length; i++)
            {
                if (dogs[i].selected)
                {
                    dog = dogs[i];
                }
            }
        }

        //Get & set dog info
        if (dog != null)
        {
            dogNameTxt.text = dog.getName();

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
