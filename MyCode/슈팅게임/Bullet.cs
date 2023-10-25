using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject bombEF;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //트리거 충돌 판정이 진행됐을 때 작업할 내용
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(bombEF, transform.position, Quaternion.identity);
            //충돌이 발생한 위치에 폭탄 이펙트 생성
            Destroy(gameObject);
            
        }

    }
}
