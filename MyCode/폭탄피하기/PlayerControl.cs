using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// ��ư�� ������ �� ��� 1ĭ�� �̵��ϴ� �ڵ�
///
/// </summary>
public class PlayerControl : MonoBehaviour
{
    public GameObject player;


    public void OnLButtonEnter()
    {
        player.transform.Translate(-1, 0, 0);
        //�ش� �ڵ��� transform�� �� ��ũ��Ʈ�� �����ϰ� �ִ� 
        //������Ʈ�� transform�� �ǹ��Ѵ�.
    }
    public void OnRButtonEnter()
    {
        player.transform.Translate(1, 0, 0);
    }

}
