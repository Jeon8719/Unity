using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public GameObject BombEF;
    public float speed = -5.0f;
    GameManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.tag == "Bullet")

        {
            GameManager.score += 100;
            manager.ScoreText();
            Instantiate(BombEF, transform.position, Quaternion.identity);
            //BombEF를 해당 스크립트를 끼고 있는 오브젝트의 위치에 생성한다.
            //회전 값은 없다.
            Destroy(gameObject);
            //0.5초 뒤에 파괴

        }
        if (collision.gameObject.tag == "Player")

        {
            GameManager.playerhp -= 1;
            manager.HPText();
            Instantiate(BombEF, transform.position, Quaternion.identity);
            //BombEF를 해당 스크립트를 끼고 있는 오브젝트의 위치에 생성한다.
            //회전 값은 없다.
            Destroy(gameObject);
            //0.5초 뒤에 파괴
            
        }

    }
    
    void Update()
    {

        transform.Translate(0, speed * Time.deltaTime, 0);
        //바닥에 닿을 경우 파괴
        if (transform.position.y < -5f)
        {
            Instantiate(BombEF, transform.position, Quaternion.identity);
            //BombEF를 해당 스크립트를 끼고 있는 오브젝트의 위치에 생성한다.
            //회전 값은 없다.
            Destroy(gameObject);
            //0.5초 뒤에 파괴
        }


    }


    //플레이어와 접촉시 파괴



}
