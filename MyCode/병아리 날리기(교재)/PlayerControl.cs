using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������Ʈ�� ������ ����� ��Ʈ�ѷ�
/// 
/// </summary>
public class PlayerControl : MonoBehaviour
{
    public float speed = 8f;
    public float moveableRange = 5.5f;
    [Header("�߻���")]
    public float power = 1000f;
    public GameObject cannonball;
    public Transform spawnpoint;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        //Input.GetAxisRaw�� ���� �¿� �̵����� * �̵��ӵ��� �̵�
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -moveableRange, moveableRange),transform.position.y);
        //Player�� �̵������� ������ ���·� ��ġ�� ǥ�� (Mathf.Clamp(��, �ּ�,�ִ�))    

        if(Input.GetKeyDown(KeyCode.Space) )
        {
            shoot();
        }

    }

    private void shoot()
    {
        GameObject newbullet = 
            Instantiate(cannonball, spawnpoint.position, Quaternion.identity) as GameObject;
        newbullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power);
    }
}
