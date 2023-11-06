using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("스크롤 제한")]
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;
    [Header("서브 스크린")]
    public GameObject subScreen;
    [Header("강제 스크롤링")]
    public bool isForceScrollX = false;
    public float forceScrollSpeedX = 0.5f;
    public bool isForceScrollY = false;
    public float forceScrollSpeedY = 0.5f;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) 
        {
            //플레이어 좌표 갱신
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            //가로 방향에 대한 동기화 (강제 스크롤)
            if(isForceScrollX)
            {
                x= transform.position.x + (forceScrollSpeedX * Time.deltaTime);
            }

            //이동 제한 적용(가로)
            if(x < leftLimit)
            {
                leftLimit = x;
            }
            else if(x > rightLimit)
            {
                rightLimit = x;
            }
            //세로 방향에 대한 동기화 (강제 스크롤)
            if (isForceScrollY)
            {
                y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
            }
            //이동 제한 적용(세로)
            if (y < bottomLimit)
            {
                bottomLimit = y;
            }
            else if( y > topLimit)
            {
                topLimit = y;
            }
            //카메라 위치 좌표 설정
            Vector3 v3 = new Vector3 (x, y+3, z);
                transform.position = v3;

            //서브 스크린에 대한 스크롤
            if(subScreen != null)
            {
                y = subScreen.transform.position.y;
                z = subScreen.transform.position.z;
                Vector3 v = new Vector3 (x / 2.0f, y, z);
                //subScreen의 x좌표는 카메라 이동량의 절반으로 설정
                subScreen.transform.position = v;
            }



        }



    }


}
