using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFlow : MonoBehaviour
{
    //게임 오브젝트 생성할 때 최초 실행
    void Awake()
    {
        Debug.Log("플레이어 데이터가 준비되었습니다.");
    }

    //게임 오브젝트가 활성화 되었을때
    //bool처럼 켜고 끄고 할때마다 실행된다.
    void OnEnable()
    {
        Debug.Log("플레이어가 로그인했습니다.");
    }

    //업데이트 시작 직전, 최초실행
    void Start()
    {
        Debug.Log("사냥 장비를 챙겼습니다.");
    }

    //------------------------프레임--------------------------------//
    //물리로직 연산에 주로 사용 주기적인 업데이트 : 고정된 실행 주기로 CPU를 많이 사용
    void FixedUpdate()
    {
        Debug.Log("용사가 사냥하러 이동~");
    }

    //주기적으로 변하는 업데이트:컴퓨터 성능 환경에 따라 실행 주기가 떨어질 수 있다.
    //fixedUpdate보다 더 실행 될수도 있고 덜 실행 될수도 있다.
    void Update()
    {
        Debug.Log("몬스터 사냥!");
    }

    //모든 업데이트 끝난후 마지막으로 실행되는 업데이트 함수로
    //캐릭터를 따라가는 카메라, 로직의 후처리
    void LateUpdate()
    {
        Debug.Log("경험치 획득");
    }


    //게임 오브젝트가 비활성화 되었을때
    void OnDisable()
    {
        Debug.Log("플레이어가 로그아웃했습니다.");
    }

    //------------------------해체영역--------------------------------//
    //게임 오브젝트가 삭제될때 무언가 남기고 삭제된다.
    //연속 총을 쏠때 총알이 땅에 떨어진것을 삭제하지 않으면 쌓여서 방해가 되므로 일정시간이 지나면 삭제시킬때
    //삭제하면 실행된다.
    void OnDestroy()
    {
        Debug.Log("플레이어 데이터를 해제하였습니다.");
    }
}
