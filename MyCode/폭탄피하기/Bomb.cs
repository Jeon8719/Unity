using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject BombEF;
    public float speed = -5.0f;
    //��ź ������ ���� �ִ� ���ϼӵ�
    //public���� ����Ƽ ���� ���� ����
    //�ܺ� �ڵ忡���� ���� ����
    //������, ���̵� � ���� ��ȭ �ֱ� ����.

    GameManager manager;
    GameObject player;
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("player");
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        //�ٴڿ� ���� ��� �ı�
        if (transform.position.y < -5.44f)
        {
            Instantiate(BombEF, transform.position, Quaternion.identity);
            //BombEF�� �ش� ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ��ġ�� �����Ѵ�.
            //ȸ�� ���� ����.
            Destroy(gameObject);
            //0.5�� �ڿ� �ı�
        }
        //�÷��̾�� ���˽� �ı�
        Vector2 Bomb_Vector = transform.position;
        Vector2 Player_Vector = player.transform.position;
        float distance = Vector2.Distance(Player_Vector, Bomb_Vector);
        
        if(distance < 1.5f)
        {
            manager.GameOver(); //�Ŵ����� ���� ���� ȣ��
            Instantiate(BombEF, transform.position, Quaternion.identity); //��ź ����Ʈ
            Destroy(gameObject);//��ź�� �ı�
        }



    }
}
