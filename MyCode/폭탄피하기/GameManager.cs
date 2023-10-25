using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Gameoverpanel; //게임 오버 패
    public Text score_text;
    public GameObject message_text;
    public static bool isOver = false; //게임 오버 여부
    public static int score;//게임 점수
 

    //static 사용시 별도 인스턴스 생성 없이 값 사용



    private void Start()
    {
        Gameoverpanel.SetActive(false); //게임 패널 off
        message_text.SetActive(false);

        score = 0;
        score_text.text = $"{score}";



    }
    public void ScoreText()
    {
        score_text.text = $"{score}";
    }




    public void OnRetryButtonEnter()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        // SampleScene 로드
        //이 기능은 BuildSettings에 씬이 연결이 되있을 경우에만 사용가능

    }
    public void GameOver()
    {
        Gameoverpanel.SetActive(true); //게임 패널 ON

        Time.timeScale = 0;
        //게임 시간의 흐름
        //기본 값은 1로 설정되있을 때 게임 시간과 현실 시간과 동일
        //해당 스케일 2가 되면 시간이 2배가 되며 0일 경우 시간은 흐르지 않는다.


    }
    public void TextMessage()
    {
        message_text.SetActive(true);
    }


}

