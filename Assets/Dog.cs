using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;

    // Start is called before the first frame update
    //void Start()
    //{
    //    
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    
    //}

    private void OnMouseOver()
    {
        infoPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        infoPanel.SetActive(false);
    }
}
