using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownTester : MonoBehaviour
{
 public Dropdown dropdown;

    private void Start()
    {
       initDropdown();
    }
    void initDropdown()
    {
        dropdown.options.Clear();
        SetDropdownOption(5);
        dropdown.onValueChanged.AddListener(OptionSelected);
    }

    public void OptionSelected(int value)
    {
 
        Debug.Log($"���õ� Option�� {dropdown.options[value].text}�Դϴ�.");

    }

    private void SetDropdownOption(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = $"�ɼ� {i+1}";
            dropdown.options.Add(option);
        }
    }




}
