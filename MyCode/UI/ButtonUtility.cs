using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUtility : MonoBehaviour
{
    public Button button01;
    public Button button02;
    public Button button03;
    public RectTransform BG;
    public Text text01;
    //스크립트를 통해 버튼 연결
    //버튼에 기능을 추가하는 2가지 방법
    //1. 일반 public 형태의 함수를 만들어서 버튼 컴포넌트에 OnClick을 추가 후
    //오브젝트를 연결하고 함수를 접근하게 만든다.

    //Listerner 관련 문법 정리
    //1. button01.onClick.AddListener(함수 이름);
    //2. button01.onClick.AddListener(() => 함수의 이름(값)); 값 전달 이벤트 연결
    //3. button01.onClick.RemoveListener(함수 이름): 연결된 이벤트 해제
    //4. button01.onClick.RemoveAllListener(함수 이름): 연결된 이벤트 모두 해제

    //inspector를 통해 직접 UnityEvent에 등록하는 경우와 
    //AddListener를 통해 등록하는 경우의 차이

    //1)inspector의 경우
    //지속성(inspector 내에서만 삭제 가능 코드로는 못 지움



    //2)AddListener의 경우 비지속성
    //(코드로만 삭제 가능 




    // Start is called before the first frame update
    void Start()
    {

        button01.onClick.AddListener(OnButtonEnter);
        //onClick.AddListener는 onClick으로부터 이벤트 리스너를 추가하는 코드
        //이벤트 리스너(Event Listener)는 이벤트 발생시 그 처리를 담당하는 전용 함수
        //=이벤트 핸들러(Event Handler)

        button02.onClick.AddListener(() => OnButtonEnter(10));
        //pararmeter가 지정되어있는 함수는 Lamda Expresssion(람다식)을 활용해 연결
        //
        button03.onClick.AddListener(CallBG);



    }

    private void CallBG()
    {
        StartCoroutine(BGLerp());
        //IEnumerator 형태의 함수를 실행
        //IEnumerator = C#의 열거자라고 불리는 데이터 형태
        //-yield 1개 이상 필요
        //IEnumerator 자체는 별도 구현 기능이 없어서 내부 기능 설계자를 구현해야한다.

        //yield는 일종의 정지 기능
        //yield return에 의해 함수를 호출해준 곳에 값을 전달후 다시 함수로 돌아와
        //yield return을 실행 (왔다갔다하는 코드)

    }

    private IEnumerator BGLerp()
    {


        Vector3 start = BG.anchoredPosition;
        Vector3 target = BG.anchoredPosition.x < -310 ? new Vector3(-310, 0, 0) : new Vector3(-1545, 0, 0);
        //삼항 연산자
        //조건식 ? : 조건식이 맞을 경우의 결과 : 조건식이 틀릴 경우의 결과;
        //설계 구조 상 a 아니면 b라고 확정되는 경우 if를 대체 가능
        float time_check = 0.0f;
        while (time_check < 1.0f)
        {
            BG.anchoredPosition = Vector3.Lerp(start, target, time_check / 1.0f);
            time_check += Time.deltaTime;
                yield return null;//한 프레임마다 반복 탈출
            /*
                        yield return new WaitForEndOfFrame();//프레임 끝날때까지 대기
                        yield return new WaitForFixedUpdate();//FixedUpdate  함수 종료까지 대기
                        yield return new WaitForSeconds(1);//1초대기
                        yield return new WaitForSecondsRealtime(time);//실제 시간만큼 대기
            */

        }
        BG.anchoredPosition = target;

        }
        //Vector3.Lerp(시작위치,도착위치,간격);
        //시작위치에서 도착위치까지 부드럽게 이동하는 코드 (선형 보간)
        //간격은 0~1 사이로 고정
        //간격 = 0이면 시작 위치 return
        //간격 = 1이면 시작 위치를 도착 위치로 return
        //간격 = 0.5일 경우 시작과 도착 지점의 종간 지점에 도달
        //수식 : 시작위치 * (1-간격) + 도착위치 * 간격

        //문제점 : Lerp는 Update에서 한 프레임에 한 동작을 진행
        //버튼으로 실행하면 끊김
        //계전 방향 : 반복을 진행하며, 특정 시간마다 반복을 탈출할 수 있는 코루틴으로 설계
        /*if (BG.anchoredPosition.x <= -340)
        {
            BG.anchoredPosition = Vector3.Lerp(BG.anchoredPosition, new Vector2(-340, 0), 1f * Time.deltaTime);
        }
        else
        {
            BG.anchoredPosition = Vector3.Lerp(BG.anchoredPosition, new Vector2(-1245, 0), 1f * Time.deltaTime);
        }
        */
    

    //같은 이름의 매개변수의 데이터 개수, 데이터 작성 순서가 다른 경우
    //같은 이름이라도 다른 기능으로 판단함 (Method Overloading)
    private void OnButtonEnter(int v)
    {
        text01.text += v;
    }

    private void OnButtonEnter()
    {
        text01.text = "버튼 이벤트 연결 성공!";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
