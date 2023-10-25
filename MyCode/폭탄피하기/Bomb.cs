using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject BombEF;
    public float speed = -5.0f;
    //폭탄 개인이 갖고 있는 낙하속도
    //public으로 유니티 내부 수정 가능
    //외부 코드에서도 접근 가능
    //아이템, 난이도 등에 따라 변화 주기 용이.

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
        //바닥에 닿을 경우 파괴
        if (transform.position.y < -5.44f)
        {
            Instantiate(BombEF, transform.position, Quaternion.identity);
            //BombEF를 해당 스크립트를 끼고 있는 오브젝트의 위치에 생성한다.
            //회전 값은 없다.
            Destroy(gameObject);
            //0.5초 뒤에 파괴
        }
        //플레이어와 접촉시 파괴
        Vector2 Bomb_Vector = transform.position;
        Vector2 Player_Vector = player.transform.position;
        float distance = Vector2.Distance(Player_Vector, Bomb_Vector);
        
        if(distance < 1.5f)
        {
            manager.GameOver(); //매니저의 게임 오버 호출
            Instantiate(BombEF, transform.position, Quaternion.identity); //폭탄 이펙트
            Destroy(gameObject);//폭탄은 파괴
        }



    }
}
