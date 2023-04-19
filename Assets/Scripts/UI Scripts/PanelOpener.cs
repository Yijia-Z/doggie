using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private AudioSource button;


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
                if (!button.isPlaying) {
                  button.Play();
                }

            }
            else
            {
                panel.SetActive(false);
            }

        }
        Debug.Log("Panel Opened");
    }
}
