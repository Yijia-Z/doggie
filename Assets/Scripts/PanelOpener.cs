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
            panel.SetActive(true);
            
        }
        Debug.Log("clicked");
    }
}
