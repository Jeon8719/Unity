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
        // SampleScene �ε�
        //�� ����� BuildSettings�� ���� ������ ������ ��쿡�� ��밡��

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
