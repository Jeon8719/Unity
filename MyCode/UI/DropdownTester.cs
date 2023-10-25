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
 
        Debug.Log($"선택된 Option은 {dropdown.options[value].text}입니다.");

    }

    private void SetDropdownOption(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = $"옵션 {i+1}";
            dropdown.options.Add(option);
        }
    }




}
