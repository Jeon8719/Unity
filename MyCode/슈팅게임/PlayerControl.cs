using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
/// <summary>
/// 플레이어의 이동을 진행하기 위한 코드 (물리 엔진 기반)
/// 
/// 
/// </summary>
public class PlayerControl : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody2D rbody;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // 변수에 Rigidboby 연결

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    /// <summary>
    /// 플레이어의 좌 우 이동 코드
    /// 
    /// </summary>

    private void Move()
    {
        //이동 방향 설정
        float h = Input.GetAxisRaw("Horizontal"); //수평이동
        float v = Input.GetAxisRaw("Vertical");   //수직이동
        
        //거리 계산
        Vector2 vetor = new Vector2(h, v);

        //속력 = 거리 * 힘
        //업데이트에서 로직이 실행되는 만큼 한 프레임 당의 시간을 체크하는 deltaTime을 *하여 보정

        //rbody.velocity = vetor * speed * Time.deltaTime;
        rbody.velocity = vetor * speed;








    }
}
