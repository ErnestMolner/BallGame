using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class LogicLight : MonoBehaviour
{

    public Slider slider;
    public float sliderValue;
    public Image panel;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("illumination", 0.5f);

        panel.color = new Color(panel.color.r, panel.color.b, slider.value);


    }

    void Update()
    {
       
    }
    // Update is called once per frame
    void ChangeSlider (float v)
    {
        sliderValue = v;
        PlayerPrefs.SetFloat("illumination", sliderValue);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, slider.value);
    }
}
