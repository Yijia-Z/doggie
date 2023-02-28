using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slider_ : MonoBehaviour
{
    private Slider slider;
    public TextMeshProUGUI slider_text;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider_text = GetComponent<TextMeshProUGUI>();
    }

    public void setSlider(string s, float val, float max)
    {
        slider_text.text = s;
        slider.value = val / max;
    }
}
