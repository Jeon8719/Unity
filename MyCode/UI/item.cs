using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ITEM_TYPE
{
    WEAPON,AMMOR,QUEST,����,ȭ��,����
}
/// <summary>
/// ScriptableObject : �����͸� ������ �� ����ϴ� ����(Asset)
/// ���� : ����Ƽ�� ����Ǿ �� ������ ���¸� ��� ����.
/// </summary>
[CreateAssetMenu(menuName ="items/item")]

public class item : ScriptableObject
{
    [Header ("������ �⺻ ������")]
    public Sprite item_icon;
    public string item_name;
    public string item_description;

    [Header("������ �ɷ�ġ")]
    public int item_atk;
    public int item_def;
    public ITEM_TYPE item_attribute;
    public ITEM_TYPE item_type;
    public int item_speed;


}
