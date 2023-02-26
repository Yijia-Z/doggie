using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // list of items in inventory
    public GameObject itemSlotPrefab; // prefab for item slot UI
    public Transform content; // content panel for item slots
    public Text itemNameText;
    public Text itemDescriptionText;
    public Image itemImage;
    public Text itemCountText;
    public Button useButton; // button for using the selected item
    private Item selected;

    // Function to add an item to the inventory
    public void AddItem(Item item)
    {
        if (items.Contains(item))
        {
            item.count++;
        }
        else
        {
            items.Add(item);
        }
        UpdateUI();
    }

    // Function to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            item.count--;
            if (item.count == 0)
            {
                items.Remove(item);
                selected = null;
            }
            UpdateUI();
        }
    }

    // Function to update the UI to show the current selected item
    private void UpdateUI()
    {
        // Clear content panel
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Create item slot for each item in inventory
        foreach (Item item in items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, content);
            Button button = slot.GetComponent<Button>();
            button.onClick.AddListener(delegate { SelectItem(item); });
            Text nameText = slot.transform.Find("NameText").GetComponent<Text>();
            nameText.text = item.name;
            Text countText = slot.transform.Find("CountText").GetComponent<Text>();
            countText.text = "x" + item.count.ToString();
        }

        // Update item details
        if (selected != null)
        {
            itemNameText.text = selected.name;
            itemDescriptionText.text = selected.description;
            itemImage.sprite = selected.sprite;
            itemCountText.text = "x" + selected.count.ToString();
            useButton.interactable = true;
        }
        else
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            itemImage.sprite = null;
            itemCountText.text = "";
            useButton.interactable = false;
        }
    }

    // Function to select an item from the inventory
    private void SelectItem(Item item)
    {
        selected = item;
        UpdateUI();
    }

    // Function to use the selected item on a dog
    public void UseSelected(Dog dog)
    {
        if (selected != null)
        {
            selected.Use(dog);
            RemoveItem(selected);
        }
    }
}