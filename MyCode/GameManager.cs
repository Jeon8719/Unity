using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("+++���ӿ���/Ŭ����+++")]
    public GameObject mainImage;
    public Sprite gameOver;
    public Sprite gameClear;
    public GameObject panel;
    public GameObject restartb;
    public GameObject nextb;
    [Header("+++Ÿ�̸�+++")]
    public GameObject timeBar;
    public GameObject timeText;
    TimeControl timeControl;
    [Header("���� �߰�")]
    public GameObject scoreText;
    public static int totalscore;
    public int stageScore = 0;

    private void Start()
    {
        
        Invoke("InactiveImage", 1.0f);
        panel.SetActive(false);
        timeControl = GetComponent<TimeControl>();
        if(timeBar != null )
        {
            if(timeControl.gameTime == 0.0f)
            {
                timeBar.SetActive(false);
            }
        }
        UpdateScore();
    }

    private void UpdateScore()
    {
        int score = stageScore + totalscore;
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    private void Update()
    {
      
        if (PlayerControl.gameState == "gameclear")
        {

            mainImage.SetActive(true);
            panel.SetActive(true );
            restartb.GetComponent<Button>().interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClear;
            PlayerControl.gameState = "gameend";

            if(timeControl != null )
            {
                timeControl.isTimeOver = true;
                int time = (int)timeControl.displayTime;
                totalscore += time * 10;
            }
            
            totalscore += stageScore;
            stageScore = 0;
            UpdateScore();

                
        }
        else if(PlayerControl.gameState == "gameover")
        {
            mainImage.SetActive(true);
            panel.SetActive(true );
            nextb.GetComponent<Button>().interactable=false;
            mainImage.GetComponent <Image>().sprite = gameOver;
            PlayerControl.gameState = "gameend";

            if (timeControl != null)
                timeControl.isTimeOver = true;
        }
        else if (PlayerControl.gameState == "playing")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerControl playerControl = player.GetComponent<PlayerControl>();
            if (timeControl != null)
            {
                if(timeControl.gameTime > 0.0f)
                {
                    //������ �Ҵ��� �Ҽ��� ���� ������
                    int time = (int)timeControl.displayTime;
                    //Ÿ�� �ؽ�Ʈ�� �ؽ�Ʈ�� time���� ó��
                    timeText.GetComponent<Text>().text = time.ToString();
                    if (time == 0)
                        playerControl.Gameover();
                }
            }
            if(playerControl.score != 0)
            {
                stageScore += playerControl.score;
                playerControl.score = 0;
                UpdateScore() ;
            }
        }
    }
    public void InactiveImage()
    {
        mainImage.SetActive(false);
    }

}
