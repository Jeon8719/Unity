using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public bool isCountDown = true;
    public float gameTime = 0;
    public bool isTimeOver = false;
    public float displayTime = 0;
    public float times = 0; //현재 시간

    public void Start()
    {
        //시작시 카운트다운 체크가 되어있으면 화면에 보이는 시간을 게임 시간으로 설정
        if(isCountDown)
            displayTime = gameTime;
    }
    public void Update()
    {
        if (isTimeOver == false)
        {
            times += Time.deltaTime;
            if(isCountDown)
            {
                displayTime = gameTime - times;
                if(displayTime <= times)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
            }
            else
            {
                displayTime = times;
                if(displayTime >= gameTime) 
                {
                    displayTime = gameTime;
                    isTimeOver=true;
                }
            }
            Debug.Log("TIMES :" + displayTime);
        }
    }

}
