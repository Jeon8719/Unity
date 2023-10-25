using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Gameoverpanel; //게임 오버 패
    public Text score_text;
    public Text HP_text;
    public static bool isOver = false; //게임 오버 여부
    public static int score;//게임 점수
    public static int playerhp;



private void Start()
{
    Gameoverpanel.SetActive(false); //게임 패널 off

    score = 0;
    score_text.text = $"{score}";
    playerhp = 5;
    HPText();
    ScoreText();

    }
public void ScoreText()
{
    score_text.text = $"score: {score}";
}

public void HPText()
 {
    HP_text.text = $"HP: {playerhp}";
 }



    private void Update()
    {
        if(playerhp < 1)
        {
            Gameoverpanel.SetActive(true); //게임 패널 ON

            Time.timeScale = 0;
        }
    }



}