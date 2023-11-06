using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    public float times = 0.0f;
    public float wait = 0.0f;
    public bool isMoveWhenOn = false;
    public bool isCanMove = true;
    float perDX;  //프레임당 x거리
    float perDY;  //프레임당 Y거리
    Vector3 defPos; //시작위치
    bool isReverse = false; //반전여부
    // Start is called before the first frame update
    void Start()
    {
        defPos = transform.position;
        float timestop = Time.fixedDeltaTime;
        perDX = moveX / (1.0f / timestop * times);
        perDY = moveY / (1.0f / timestop * times);
        if (isMoveWhenOn)
        {
            isCanMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanMove)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            bool endX = false;
            bool endY = false;
            if (isReverse)
            {
                //반대 방향으로 이동하는 경우
                //이동량이 양수이고 이동 위치가 초기 위치보다 작거나
                //이동량이 음수이고 이동 위치가 초기 위치보다 큰 경우
                if ((perDX >= 0.0f && x <= defPos.x) || (perDX < 0.0f && x >= defPos.x))
                {
                    endX = true; // X방향 이동 종료
                }
                if ((perDY >= 0.0f && y <= defPos.y) || (perDY < 0.0f && y >= defPos.y))
                {
                    endY = true; // Y방향 이동 종료
                }
                transform.Translate(new Vector3(-perDX, -perDY, defPos.z));
            }
            else
            {
                //정방향으로 이동하는 경우
                //이동량이 양수이고 이동 위치가 초기 위치보다 더 크거나
                //이동량이 음수이고 이동 위치가 초기 + 이동거리보다 작은 경우
                if ((perDX >= 0.0f && x >= defPos.x + moveX) || (perDX < 0.0f && x <= defPos.x + moveX))
                {
                    endX = true;
                }
                if ((perDY >= 0.0f && y >= defPos.y + moveY) || (perDY < 0.0f && y <= defPos.y + moveY))
                {
                    endY = true;
                }
                Vector3 v = new Vector3(perDX, perDY, defPos.z);
                transform.Translate(v);
            }
            if (endX && endY)
            {
                if (isReverse)
                {
                    transform.position = defPos;
                    isReverse = !isReverse;
                    isCanMove = false;
                    if (isMoveWhenOn == false)
                        Invoke("Move", wait);
                }
            }
        }
    }
    public void Move()
    {
        isCanMove = true;
    }
    public void Stop()
    {
        isCanMove = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //접촉시    
        if (collision.gameObject.tag == "Player")
        {
            //충돌체가 자식이 된다.
            collision.transform.SetParent(transform);
            if (isMoveWhenOn)
            {
                isCanMove = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //접촉 종료시
        if (collision.gameObject.tag == "Player")
        {
            //자식 해제
            collision.transform.SetParent(null);

        }
    }



}
