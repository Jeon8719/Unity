using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScrollTF : MonoBehaviour
{
    public Scrollbar Scrollbar1;
    public Scrollbar Scrollbar2;
    public Toggle Toggle1;
    public Toggle Toggle2;
    public Button Button1;


    // Start is called before the first frame update
    void Start()
    {
        Scrollbar1.onValueChanged.AddListener(Toggleonoff);
        Scrollbar2.onValueChanged.AddListener(Toggleonoff2);

    }

    private void Toggleonoff2(float value)
    {
        if (Scrollbar2.value == 0)
        {
            Toggle2.interactable = true;
        }
        else
        {
            Toggle2.interactable = false;
        }
    }

    public void Toggleonoff(float value)
    {
        if (Scrollbar1.value == 0)
        {
            Toggle1.interactable = true;
        }
        else
        {
            Toggle1.interactable = false;
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Toggle1.isOn == true && Toggle2.isOn == true)
        {
            Button1.interactable = true;
        }
        else
        {
            Button1.interactable = false;
        }
    }
}
