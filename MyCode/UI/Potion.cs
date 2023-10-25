using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public Button potion_button; //리스너 전달용 버튼
    public Image potion_Image; //포션 이미지 filled 타입
    public Text potion_cooltext; //포션 쿨 TEXT
    public Text potion_text; //포션 개수 TEXT
    public int potion_count; //포션 개수 데이터
    public int hp; //포션 회복량
    public float cool_time = 3.0f; //쿨
    public float time_check = 3.0f; //시간체크


    // Start is called before the first frame update
    void Start()
    {
        potion_count = int.Parse(potion_text.text);
        //텍스트를 통해 포션 개수를 수령
        potion_button.onClick.AddListener(OnPotionButtonEnter);
        //포션 버튼에 OnPotionButtonEnter 함수 전달
    }
    public void OnPotionButtonEnter()
    {
        StartCoroutine(UsePotion());
        //코루틴 UsePotion 실행
    }

    private IEnumerator UsePotion()
    {
        Debug.Log($"체력 {50} 회복");
        potion_count--;//포션 차감
        potion_text.text = potion_count.ToString();//포션 카운트 변경
        potion_button.enabled = false;

        while(time_check > 0.0f)//쿨타임만큼 반복
        {
            time_check -= Time.deltaTime; //타임체크
            potion_Image.fillAmount = time_check / cool_time;//타임체크/전체시간의 수치만큼 이미치 채우기

            string time = TimeSpan.FromSeconds(time_check).ToString("s\\:ff");
            //남은 시간 체크를 분과 초의 형태로 표현
            //분과 초를 분리
            string[] t = time.Split(":");
            potion_cooltext.text = $"{t[0]} : {t[1]}";
            yield return new WaitForFixedUpdate();

        }
        //while 탈출 후 리셋
        potion_button.enabled = true;
        potion_Image.fillAmount = 1;
        potion_cooltext.text = "";
        time_check = cool_time;
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
