using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 오브젝트에 연결해 사용할 컨트롤러
/// 
/// </summary>
public class PlayerControl : MonoBehaviour
{
    public float speed = 8f;
    public float moveableRange = 5.5f;
    [Header("발사기능")]
    public float power = 1000f;
    public GameObject cannonball;
    public Transform spawnpoint;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        //Input.GetAxisRaw를 통해 좌우 이동방향 * 이동속도로 이동
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -moveableRange, moveableRange),transform.position.y);
        //Player의 이동범위를 제한한 상태로 위치를 표현 (Mathf.Clamp(값, 최소,최대))    

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
