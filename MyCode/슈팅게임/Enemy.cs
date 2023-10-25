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
            //BombEF�� �ش� ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ��ġ�� �����Ѵ�.
            //ȸ�� ���� ����.
            Destroy(gameObject);
            //0.5�� �ڿ� �ı�

        }
        if (collision.gameObject.tag == "Player")

        {
            GameManager.playerhp -= 1;
            manager.HPText();
            Instantiate(BombEF, transform.position, Quaternion.identity);
            //BombEF�� �ش� ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ��ġ�� �����Ѵ�.
            //ȸ�� ���� ����.
            Destroy(gameObject);
            //0.5�� �ڿ� �ı�
            
        }

    }
    
    void Update()
    {

        transform.Translate(0, speed * Time.deltaTime, 0);
        //�ٴڿ� ���� ��� �ı�
        if (transform.position.y < -5f)
        {
            Instantiate(BombEF, transform.position, Quaternion.identity);
            //BombEF�� �ش� ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ��ġ�� �����Ѵ�.
            //ȸ�� ���� ����.
            Destroy(gameObject);
            //0.5�� �ڿ� �ı�
        }


    }


    //�÷��̾�� ���˽� �ı�



}
