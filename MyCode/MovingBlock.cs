using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    public float times = 0.0f;
    public float wait = 0.0f;
    public bool isMoveWhenOn = false;
    public bool isCanMove = true;
    float perDX;  //�����Ӵ� x�Ÿ�
    float perDY;  //�����Ӵ� Y�Ÿ�
    Vector3 defPos; //������ġ
    bool isReverse = false; //��������
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
                //�ݴ� �������� �̵��ϴ� ���
                //�̵����� ����̰� �̵� ��ġ�� �ʱ� ��ġ���� �۰ų�
                //�̵����� �����̰� �̵� ��ġ�� �ʱ� ��ġ���� ū ���
                if ((perDX >= 0.0f && x <= defPos.x) || (perDX < 0.0f && x >= defPos.x))
                {
                    endX = true; // X���� �̵� ����
                }
                if ((perDY >= 0.0f && y <= defPos.y) || (perDY < 0.0f && y >= defPos.y))
                {
                    endY = true; // Y���� �̵� ����
                }
                transform.Translate(new Vector3(-perDX, -perDY, defPos.z));
            }
            else
            {
                //���������� �̵��ϴ� ���
                //�̵����� ����̰� �̵� ��ġ�� �ʱ� ��ġ���� �� ũ�ų�
                //�̵����� �����̰� �̵� ��ġ�� �ʱ� + �̵��Ÿ����� ���� ���
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
        //���˽�    
        if (collision.gameObject.tag == "Player")
        {
            //�浹ü�� �ڽ��� �ȴ�.
            collision.transform.SetParent(transform);
            if (isMoveWhenOn)
            {
                isCanMove = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //���� �����
        if (collision.gameObject.tag == "Player")
        {
            //�ڽ� ����
            collision.transform.SetParent(null);

        }
    }



}
