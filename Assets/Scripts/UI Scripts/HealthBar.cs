using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Dog dog;

    //for selecting dog w/ mouse
    private Camera _camera;
    private Renderer _renderer;
    private Ray ray;
    private RaycastHit hit;

    //for dog stats
    string dogName;
    public Sprite dogImage;
    int dogHealth;             //health = hunger, energy, or happiness
    int maxHealth;
    public Text nameTxt;

    public Image ProgressImage;
    private Slider hungerSlider;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _renderer = GetComponent<Renderer>();
        hungerSlider = GetComponent<Slider>();
        dog = null;
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

                    //Get dog functions
                    /*
                    dogName =

                    dogImage = 
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Moon;

                    hungerSlider.value = dog.getHealth() / maxHealth
                    //repeat for other sliders


                    */
                }
            }
        }
    }
}
