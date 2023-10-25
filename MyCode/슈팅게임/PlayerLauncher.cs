using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public GameObject bulletPrefab; //투사체

    private void Update()
    {
        Fire();

    }
    /// <summary>
    /// 마우스를 클릭하면 총알이 발사되는 코드
    /// </summary>
    private void Fire()
    {
        //GetMouseButton : 누르는 동안 작동 
        //GetMouseButtonDown : 눌렀을 경우 (1회)
        //GetMouseButtonUp : 땠을 경우 (1회)
        
        // 숫자 0 : 왼쪽, 1 : 오른쪽, 2 : 마우스 휠

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletoj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            
            //2. 위로 발사
            //2-1. 총알 물리엔진 적용을 위해 리지드바디 호출
            //2-2. 투사체에 순간적인 힘을 가해 위로 발사.
            Rigidbody2D rbody = bulletoj.GetComponent<Rigidbody2D>();
            rbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            //ForceMode는 물리 엔진에서 힘의 처리를 계산할 떄 사용하는 enum
            //Force : 서서히
            //Impulse : 순간적인

        }






    }
}
