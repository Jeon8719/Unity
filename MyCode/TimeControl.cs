using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public bool isCountDown = true;
    public float gameTime = 0;
    public bool isTimeOver = false;
    public float displayTime = 0;
    public float times = 0; //���� �ð�

    public void Start()
    {
        //���۽� ī��Ʈ�ٿ� üũ�� �Ǿ������� ȭ�鿡 ���̴� �ð��� ���� �ð����� ����
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
