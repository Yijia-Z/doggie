using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;


    void Start()
    {
        //panel = GetComponent<GameObject>();
    }

    public void OpenPanel()
    {
        if (panel != null)
        {
            if (panel.activeSelf == false)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
            
        }
        Debug.Log("clicked");
    }
}
