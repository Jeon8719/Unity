using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIManager : MonoBehaviour
{
    [Header("이용 약관")]
    public Toggle confirm1;
    public Scrollbar confirm_check1;
    [Header("개인 정보 이용")]
    public Toggle confirm2;
    public Scrollbar confirm_check2;
    [Header("확인")]
    public Button confirm_btn;

    public Text perms;
    public Text privacy;

    string perms_txt = "";
    string privacy_txt = "";

    // Start is called before the first frame update
    void Start()
    {
        ReadData("Files", "perm", perms_txt, perms);
        ReadData("Files", "privacy policy", privacy_txt, privacy);
        confirm_check1.onValueChanged.AddListener(delegate { OnConfirmCheck(confirm1,confirm_check1); });
        confirm_check2.onValueChanged.AddListener(delegate { OnConfirmCheck(confirm2,confirm_check2); });
    }

    public void OnConfirmCheck(Toggle confirm, Scrollbar check)
    {
        if (check.value == 0)
            confirm.interactable = true;
    }

    private void Update()
    {
        if(confirm1.isOn && confirm2.isOn)
            confirm_btn.interactable=true;
        else
            confirm_btn.interactable=false;
    }

    public void ReadData(string folder, string file_name, string data, Text text)
    {
        StreamReader sr = new StreamReader($"{Application.dataPath}/{folder}/{file_name}.txt");
        data = sr.ReadToEnd();
        text.text = data;
        sr.Close();
    }

}
