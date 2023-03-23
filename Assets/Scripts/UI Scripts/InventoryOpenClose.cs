using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpenClose : MonoBehaviour
{
    public GameObject InventoryPanel1;
    public GameObject InventoryPanel2;
    public GameObject InventoryPanel3;

    public GameObject Button;

    //When folder icon is clicked, show inventory
    public void OpenInventory()
    {
        if (InventoryPanel1 != null)
        {
            InventoryPanel1.SetActive(true);
        }
        if (InventoryPanel2 != null)
        {
            InventoryPanel2.SetActive(true);
        }
        if (InventoryPanel3 != null)
        {
            InventoryPanel3.SetActive(true);
        }
        if (Button != null)
        {
            Button.SetActive(false);
        }
    }

    //When close arrow is clicked, hide inventory & show folder icon
    public void CloseInventory()
    {

    }
}
