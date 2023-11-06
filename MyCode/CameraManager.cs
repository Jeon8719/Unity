using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("��ũ�� ����")]
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;
    [Header("���� ��ũ��")]
    public GameObject subScreen;
    [Header("���� ��ũ�Ѹ�")]
    public bool isForceScrollX = false;
    public float forceScrollSpeedX = 0.5f;
    public bool isForceScrollY = false;
    public float forceScrollSpeedY = 0.5f;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) 
        {
            //�÷��̾� ��ǥ ����
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            //���� ���⿡ ���� ����ȭ (���� ��ũ��)
            if(isForceScrollX)
            {
                x= transform.position.x + (forceScrollSpeedX * Time.deltaTime);
            }

            //�̵� ���� ����(����)
            if(x < leftLimit)
            {
                leftLimit = x;
            }
            else if(x > rightLimit)
            {
                rightLimit = x;
            }
            //���� ���⿡ ���� ����ȭ (���� ��ũ��)
            if (isForceScrollY)
            {
                y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
            }
            //�̵� ���� ����(����)
            if (y < bottomLimit)
            {
                bottomLimit = y;
            }
            else if( y > topLimit)
            {
                topLimit = y;
            }
            //ī�޶� ��ġ ��ǥ ����
            Vector3 v3 = new Vector3 (x, y+3, z);
                transform.position = v3;

            //���� ��ũ���� ���� ��ũ��
            if(subScreen != null)
            {
                y = subScreen.transform.position.y;
                z = subScreen.transform.position.z;
                Vector3 v = new Vector3 (x / 2.0f, y, z);
                //subScreen�� x��ǥ�� ī�޶� �̵����� �������� ����
                subScreen.transform.position = v;
            }



        }



    }


}
