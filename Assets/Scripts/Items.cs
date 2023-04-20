using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int count; // number of items in inventory
    public int value; // value of each item
    public string name; // name of the item
    public Sprite sprite; // icon image for the item
    public string description; // description of the item

    // Constructor for Item class
    public Item(int count, int value, string name, Sprite sprite, string description)
    {
        this.count = count;
        this.value = value;
        this.name = name;
        this.sprite = sprite;
        this.description = description;
    }

    // Function to spend the item on a dog class instance
    public virtual void Use(Dog dog)
    {
        Debug.Log("Item " + name + " used on dog " + dog.getName());
    }
}

public class Food : Item
{
    // Constructor for Food class, inheriting from Item
    public Food(int count, int value, string name, Sprite sprite, string description)
        : base(count, value, name, sprite, description) { }

    // Override Use function to consume the food and increase dog's hunger
    public override void Use(Dog dog)
    {
        dog.hunger += value; // or value of the item
        dog.giveFood();
        //count--;
        Debug.Log("Food " + name + value + " used on dog " + dog.getName());
    }
}

public class Toy : Item
{
    // Constructor for Toy class, inheriting from Item
    public Toy(int count, int value, string name, Sprite sprite, string description)
        : base(count, value, name, sprite, description) { }

    // Override Use function to equip the toy on the dog
    public override void Use(Dog dog)
    {
        dog.equippedToy = this;
        dog.happiness += value;
        dog.giveToy();
        //count--;
        Debug.Log("Toy " + name + value + " equipped on dog " + dog.getName());
    }
}
public class Apparel : Item
{
    // Constructor for Apparel class, inheriting from Item
    public Apparel(int count, int value, string name, Sprite sprite, string description)
        : base(count, value, name, sprite, description) { }

    // Override Use function to equip the Apparel on the dog
    public override void Use(Dog dog)
    {
        dog.equippedApparel = this;
        if (name == "Neckpiece")
        {
            dog.neckpieceImage.sprite = sprite;
        }
        else if (name == "Headpiece")
        {
            dog.headpieceImage.sprite = sprite;
        }

        dog.happiness += value;
        dog.giveApparel();
        //count--;
        Debug.Log("Apparel " + name + value + " equipped on dog " + dog.getName());
    }
}
