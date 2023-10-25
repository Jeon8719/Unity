using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 버튼을 눌러서 좌 우로 1칸씩 이동하는 코드
///
/// </summary>
public class PlayerControl : MonoBehaviour
{
    public GameObject player;


    public void OnLButtonEnter()
    {
        player.transform.Translate(-1, 0, 0);
        //해당 코드의 transform은 이 스크립트를 연결하고 있는 
        //오브젝트의 transform을 의미한다.
    }
    public void OnRButtonEnter()
    {
        player.transform.Translate(1, 0, 0);
    }

}
