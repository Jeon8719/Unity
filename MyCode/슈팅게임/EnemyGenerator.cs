using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy; //��ź ������
    float SpawnTime = 1.0f; //1�ʸ��� ����
    float time_check = 0;   //�ð� üũ�� ����

    GameManager gameManager; //���� �Ŵ��� ȣ��

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        //1. GameObject�� ����� find�� ����Ƽ ���� ������ gameManager������Ʈ�� �˻�.
        //2. �� �� GetComponent<GameManager>()�� ���� �ش� ������Ʈ�κ��� GameManager ������Ʈ�� ����� ����
        //��������� ���� ������Ʈ�� ã�� ���� �Ŵ����� ���� ���´�.

        //���ǻ��� :
        //����Ƽ hierachy�� GameManager ������Ʈ�� �����ؾ��Ѵ�.
        //�ش� ������Ʈ�� �ݵ�� GameManager.cs ��ũ��Ʈ�� �־�� �Ѵ�.
        //������Ʈ�� ����� ��ũ��Ʈ�� Component�� �ȴ�.


        //gameManager = GetComponent<GameManager>();
        //GetComponent <>�ȿ� ������ ����� �̸��� ���� �ش� ����� ���
    }



    // 1. �ð� ����(������ �� �ð�)
    // 2. ������ �ð��� ���� �ð��� �ʰ��� ��� ���� ����
    // 3. ���� ��ġ�� ���� �Ǵ� ������ ��ġ
    void Update()
    {
        time_check += Time.deltaTime;
        //GameManager.score += (int)time_check * 100;
        //gameManager.ScoreText();

        if (time_check > SpawnTime)
        {

            time_check = 0; // �ð� ������ ������ �ٽ� ����ó��.
            GameObject go = Instantiate(Enemy); // ��ź ����
            int random_x = Random.Range(-16, 16);
            go.transform.position = new Vector2(random_x, 8.5f);

        }
    }
}
