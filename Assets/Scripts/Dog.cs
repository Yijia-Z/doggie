using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dog : MonoBehaviour
{
    [SerializeField] Sprite dogImage;
    [SerializeField] string dogName = "default_name";
    [SerializeField] int dogOwnerIndex;

    public GameObject attention;
    public Item item;
    public Toy equippedToy = null;
    public Apparel equippedApparel = null;
    public float hunger = 50f;
    public float hygiene = 100f;
    public float totalHappiness = 100f;
    public float happiness = 30f;
    public bool selected = false;

    private float secToMinRatio;
    private float timer;
    private Clock clock;

    public GameObject taskPanel;
    public Button bathe_button;
    public Button walk_button;
    public Button give_item_button;
    public GameObject inventory_panel;
    public GameObject stats_panel;
    Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<Clock>();
        secToMinRatio = clock.irlSecToGameMinRatio;

        bathe_button.onClick.AddListener(giveBath);
        walk_button.onClick.AddListener(giveWalk);
        give_item_button.onClick.AddListener(openInventory);
        buttons = inventory_panel.GetComponentsInChildren<Button>(true);

        // add listener to all buttons in the inventory panel
        foreach (Button button in buttons)
        {
            if (button.tag == "Food" || button.tag == "Toy" || button.tag == "Apparel")
            {
                button.onClick.AddListener(() =>
                {
                    Debug.Log(button.tag);
                    item = CreateInstanceFromTag(button.tag);
                });
                button.onClick.AddListener(OnClick);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set max values for stats
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

    }

    // Show dog info panel when mouse CLICKS dog
    private void OnMouseDown()
    {
        Dog[] dogs = FindObjectsOfType<Dog>();
        for (int i = 0; i < dogs.Length; i++)
        {
            dogs[i].selected = false;
            dogs[i].taskPanel.SetActive(false);
            dogs[i].stats_panel.SetActive(false);
        }

        selected = true;

        //show/hide stats and tasks
        openCloseStats();
        openCloseTasks();

        Vector3 dogPos = gameObject.transform.localPosition;
    }

    // !!!!!!! Not used anymore. Panel stuff is handled in panel script
    public void closeInfoPanel()
    {
        //infoPanel.SetActive(false);
        taskPanel.SetActive(false);
        selected = false;
    }

    // Calculates total happiness (what is displayed) from the other stats
    private void updatetotalHappiness()
    {
        totalHappiness = ((hunger / 100f) * 40) + ((hygiene / 100f) * 30) + happiness;
        if (totalHappiness < 30f)
        {
            attention.SetActive(true);
        }
        else
        {
            attention.SetActive(false);
        }
        if (selected)
        {
            attention.SetActive(false);
        }
        if (totalHappiness > 100f)
        {
            totalHappiness = 100f;
        }
    }

    // Decrease the dog's stats over time
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

    public void openCloseStats()
    {
        //if off, turn on
        if (stats_panel.activeSelf == false)
        {
            stats_panel.SetActive(true);
        }
        else
        {
            stats_panel.SetActive(false);
        }
    }

    public void openCloseTasks()
    {
        //if off, turn on
        if (taskPanel.activeSelf == false)
        {
            taskPanel.SetActive(true);
        }
        else
        {
            taskPanel.SetActive(false);
        }
    }

    public void openInventory()
    {
        // display inventory
        inventory_panel.SetActive(true);

    }
    private void OnClick()
    {
        if (selected)
        {
            item.Use(this);
        }
        inventory_panel.SetActive(false);
    }

    public static Item CreateInstanceFromTag(string tag)
    {
        Item item = null;

        switch (tag)
        {
            case "Food":
                item = new Food(100, 30, tag, null, "Delicious food for dogs");
                break;
            case "Toy":
                item = new Toy(100, 30, tag, null, "A toy for dogs to catch");
                break;
            case "Apparel":
                item = new Apparel(100, 30, tag, null, "Cloth for dogs to wear");
                break;
            default:
                Debug.Log("Invalid item tag: " + tag);
                break;
        }
        return item;
    }

    // Feed task
    public void giveFood()
    {
        // hunger is added in Food class
        hygiene -= 5f;
        taskPanel.SetActive(false);
        clock.minute += 5;
    }

    // Wash task
    public void giveBath()
    {
        //Debug.Log("before: " + clock.minute);
        hygiene = 100f;
        happiness -= 15f;
        taskPanel.SetActive(false);
        clock.minute += 20;
        Debug.Log("giving bath");
        //Debug.Log("after: " + clock.minute);
    }

    // Walk task
    public void giveWalk()
    {
        happiness += 20f;
        hygiene -= 10f;
        hunger -= 15f;
        taskPanel.SetActive(false);
        clock.minute += 20;
        Debug.Log("giving walk");
    }

    // Give toy task
    public void giveToy()
    {
        // happiness is added in Toy class
        taskPanel.SetActive(false);
        clock.minute += 5;
    }
    public void giveApparel()
    {
        // happiness is added in Apparel class
        taskPanel.SetActive(false);
    }


    public string getName()
    {
        return dogName;
    }
    
    public int getOwnerIndex(){
        return dogOwnerIndex;
    }
    public float getHunger()
    {
        return hunger;
    }

    public float getHygiene()
    {
        return hygiene;
    }

    public float getHappiness()
    {
        return totalHappiness;
    }

    public Sprite getSprite()
    {
        return dogImage;
    }
}
