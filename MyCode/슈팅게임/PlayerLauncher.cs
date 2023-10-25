using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public GameObject bulletPrefab; //����ü

    private void Update()
    {
        Fire();

    }
    /// <summary>
    /// ���콺�� Ŭ���ϸ� �Ѿ��� �߻�Ǵ� �ڵ�
    /// </summary>
    private void Fire()
    {
        //GetMouseButton : ������ ���� �۵� 
        //GetMouseButtonDown : ������ ��� (1ȸ)
        //GetMouseButtonUp : ���� ��� (1ȸ)
        
        // ���� 0 : ����, 1 : ������, 2 : ���콺 ��

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletoj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            
            //2. ���� �߻�
            //2-1. �Ѿ� �������� ������ ���� ������ٵ� ȣ��
            //2-2. ����ü�� �������� ���� ���� ���� �߻�.
            Rigidbody2D rbody = bulletoj.GetComponent<Rigidbody2D>();
            rbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            //ForceMode�� ���� �������� ���� ó���� ����� �� ����ϴ� enum
            //Force : ������
            //Impulse : ��������

        }






    }
}
