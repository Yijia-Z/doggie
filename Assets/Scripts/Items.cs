using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int count; // number of items in inventory
    public string name; // name of the item
    public Sprite sprite; // icon image for the item
    public string description; // description of the item

    // Constructor for Item class
    public Item(int count, string name, Sprite sprite, string description)
    {
        this.count = count;
        this.name = name;
        this.sprite = sprite;
        this.description = description;
    }

    // Function to spend the item on a dog class instance
    public virtual void Use(Dog dog)
    {
        Debug.Log("Item " + name + " used on dog " + dog.name);
    }
}

public class Food : Item
{
    // Constructor for Food class, inheriting from Item
    public Food(int count, string name, Sprite sprite, string description)
        : base(count, name, sprite, description) { }

    // Override Use function to consume the food and increase dog's hunger
    public override void Use(Dog dog)
    {
        dog.hunger += 10; // or value of the item
        count--;
        Debug.Log("Food " + name + " used on dog " + dog.name);
    }
}

public class Toy : Item
{
    // Constructor for Toy class, inheriting from Item
    public Toy(int count, string name, Sprite sprite, string description)
        : base(count, name, sprite, description) { }

    // Override Use function to equip the toy on the dog
    public override void Use(Dog dog)
    {
        dog.equippedToy = this;
        Debug.Log("Toy " + name + " equipped on dog " + dog.name);
        // TODO: happiness calculation
    }
}
