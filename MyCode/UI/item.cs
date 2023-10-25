using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ITEM_TYPE
{
    WEAPON,AMMOR,QUEST,물리,화염,번개
}
/// <summary>
/// ScriptableObject : 데이터를 저장할 때 사용하는 에셋(Asset)
/// 장점 : 유니티가 종료되어도 그 데이터 형태를 계속 저장.
/// </summary>
[CreateAssetMenu(menuName ="items/item")]

public class item : ScriptableObject
{
    [Header ("아이템 기본 데이터")]
    public Sprite item_icon;
    public string item_name;
    public string item_description;

    [Header("아이템 능력치")]
    public int item_atk;
    public int item_def;
    public ITEM_TYPE item_attribute;
    public ITEM_TYPE item_type;
    public int item_speed;


}
