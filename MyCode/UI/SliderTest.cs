using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    public Slider slider;
    public Text slider_text;
    public float maxSliderAmount = 100.0f;
    private void Start()
    {
        slider.onValueChanged.AddListener(SetSlider);
    }
    public void SetSlider (float value)
    {
        float local_value = value * maxSliderAmount;
        slider_text.text = local_value.ToString("0.0");
    }
}
