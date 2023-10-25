using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy; //폭탄 복제본
    float SpawnTime = 1.0f; //1초마다 생성
    float time_check = 0;   //시간 체크용 변수

    GameManager gameManager; //게임 매니저 호출

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        //1. GameObject의 기능을 find로 유니티 게임 내부의 gameManager오브젝트를 검색.
        //2. 그 뒤 GetComponent<GameManager>()를 통해 해당 오브젝트로부터 GameManager 컴포넌트의 기능을 얻음
        //결과적으로 게임 오브젝트를 찾고 게임 매니저의 값을 얻어온다.

        //주의사항 :
        //유니티 hierachy에 GameManager 오브젝트가 존재해야한다.
        //해당 오브젝트는 반드시 GameManager.cs 스크립트가 있어야 한다.
        //오브젝트에 연결된 스크립트는 Component가 된다.


        //gameManager = GetComponent<GameManager>();
        //GetComponent <>안에 가져올 기능의 이름을 적고 해당 기능을 출력
    }



    // 1. 시간 측정(프레임 당 시간)
    // 2. 설정한 시간이 측정 시간을 초과할 경우 생성 진행
    // 3. 생성 위치는 랜덤 또는 정해진 위치
    void Update()
    {
        time_check += Time.deltaTime;
        //GameManager.score += (int)time_check * 100;
        //gameManager.ScoreText();

        if (time_check > SpawnTime)
        {

            time_check = 0; // 시간 측정을 리셋해 다시 측정처리.
            GameObject go = Instantiate(Enemy); // 폭탄 생성
            int random_x = Random.Range(-16, 16);
            go.transform.position = new Vector2(random_x, 8.5f);

        }
    }
}
