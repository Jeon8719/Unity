using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Gameoverpanel; //���� ���� ��
    public Text score_text;
    public GameObject message_text;
    public static bool isOver = false; //���� ���� ����
    public static int score;//���� ����
 

    //static ���� ���� �ν��Ͻ� ���� ���� �� ���



    private void Start()
    {
        Gameoverpanel.SetActive(false); //���� �г� off
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
        // SampleScene �ε�
        //�� ����� BuildSettings�� ���� ������ ������ ��쿡�� ��밡��

    }
    public void GameOver()
    {
        Gameoverpanel.SetActive(true); //���� �г� ON

        Time.timeScale = 0;
        //���� �ð��� �帧
        //�⺻ ���� 1�� ���������� �� ���� �ð��� ���� �ð��� ����
        //�ش� ������ 2�� �Ǹ� �ð��� 2�谡 �Ǹ� 0�� ��� �ð��� �帣�� �ʴ´�.


    }
    public void TextMessage()
    {
        message_text.SetActive(true);
    }


}

