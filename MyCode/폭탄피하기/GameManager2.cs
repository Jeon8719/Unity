using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager2 : MonoBehaviour
{
    public GameObject message_text;
    public GameObject button;
    private void Start()
    {
        Time.timeScale = 0;
        message_text.SetActive(false);
        button.SetActive(false);
    }
    public void StartButtonEnter()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        // SampleScene 로드
        //이 기능은 BuildSettings에 씬이 연결이 되있을 경우에만 사용가능

    }
    public void TextMessage()
    {
        message_text.SetActive(true);
        button.SetActive(true);
    }
    public void TextMessage2()
    {
        message_text.SetActive(false);
        button.SetActive(false);
    }

}
