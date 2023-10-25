using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject bombEF;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ʈ���� �浹 ������ ������� �� �۾��� ����
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(bombEF, transform.position, Quaternion.identity);
            //�浹�� �߻��� ��ġ�� ��ź ����Ʈ ����
            Destroy(gameObject);
            
        }

    }
}
