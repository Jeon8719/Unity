using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageManager : MonoBehaviour
{
    public SpriteRenderer image;
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;
    public Slider slider5;
    public Slider slider6;
   
        
    // Start is called before the first frame update
    void Start()
    {
        slider1.onValueChanged.AddListener(Rcolor);
        slider2.onValueChanged.AddListener(Gcolor);
        slider3.onValueChanged.AddListener(Bcolor);
        slider4.onValueChanged.AddListener(Acolor);
        slider5.onValueChanged.AddListener(Size);
        slider6.onValueChanged.AddListener(Rotation);
        slider1.minValue = 0;
        slider1.maxValue = 255;
        slider2.minValue = 0;
        slider2.maxValue = 255;
        slider3.minValue = 0;
        slider3.maxValue = 255;
        slider4.minValue = 0;
        slider4.maxValue = 255;
        slider5.minValue = 1;
        slider5.maxValue = 10;
        slider6.minValue = 0;
        slider6.maxValue = 360;
    }

    private void Rotation(float value)
    {
        image.transform.localRotation = Quaternion.Euler(0, 0, slider6.value);
    }

    private void Size(float value)
    {
        image.transform.localScale = new Vector3(slider5.value, slider5.value, 1);
    }

    void Rcolor(float value)
    {
        image.color = new Color(value/255, image.color.g,image.color.b, image.color.a);
    }
     void Gcolor(float value)
    {
        image.color = new Color(image.color.r, value / 255, image.color.b, image.color.a);
    }
     void Bcolor(float value)
    {
        image.color = new Color(image.color.r, image.color.g, value / 255, image.color.a);
    }

     void Acolor(float value)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, value / 255);
    }

}
