using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject otherTarget;
    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null )
        {
            transform.position = new Vector3(player.transform.position.x,
                player.transform.position.y, -10);
        }
        

    }
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (otherTarget != null)
            {
                Vector2 pos = Vector2.Lerp(player.transform.position,
                                           otherTarget.transform.position,
                                           0.5f);
                //플레이어 위치와 연동
                transform.position = new Vector3(pos.x, pos.y, -10);
            }
            else
            {
                //플레이어 위치와 연동
                transform.position = new Vector3(player.transform.position.x,
                                 player.transform.position.y,
                                                 -10);
            }
        }
    }
}
