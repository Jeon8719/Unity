using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
/// <summary>
/// �÷��̾��� �̵��� �����ϱ� ���� �ڵ� (���� ���� ���)
/// 
/// 
/// </summary>
public class PlayerControl : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody2D rbody;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); // ������ Rigidboby ����

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    /// <summary>
    /// �÷��̾��� �� �� �̵� �ڵ�
    /// 
    /// </summary>

    private void Move()
    {
        //�̵� ���� ����
        float h = Input.GetAxisRaw("Horizontal"); //�����̵�
        float v = Input.GetAxisRaw("Vertical");   //�����̵�
        
        //�Ÿ� ���
        Vector2 vetor = new Vector2(h, v);

        //�ӷ� = �Ÿ� * ��
        //������Ʈ���� ������ ����Ǵ� ��ŭ �� ������ ���� �ð��� üũ�ϴ� deltaTime�� *�Ͽ� ����

        //rbody.velocity = vetor * speed * Time.deltaTime;
        rbody.velocity = vetor * speed;








    }
}
