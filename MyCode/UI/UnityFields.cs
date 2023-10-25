using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ش� ��ũ��Ʈ�� ����Ƽ���� ����ϴ� ����(�ʵ�)�� ���� ������
/// �ٷ�� �ֽ��ϴ�.
/// </summary>
public class UnityFields : MonoBehaviour
{
    //����Ƽ���� Ȯ���� �� �ִ� ���� ������
    //1.public : ����Ƽ �����Ϳ��� ���� ���� ���� ����
    //2.private : �����Ϳ��� ���� �Ұ�
    //����ڴ� ���� ����, �ڵ忡 ���� ó���� ���� public�� private�� ����

    //����Ƽ���� �ٷ�� �⺻ ������
    [Header("�������ͽ�")]
    //�ν����Ϳ� Ÿ��Ʋ�� �ٴ� ���
    //�ش� ����� ������Ʈ�� �Ը� Ŭ���� �߿�
    public int value;
    public float f_value;
    public string word;
    public bool isCheck;
    [Tooltip("�ɷ¿� ���� ����")] public TYPE type;
    

    //����Ƽ���� ����ϴ� enum
    public enum TYPE
    {
        FIRE, WATER, LEAF
    }
    //[Range(�ּ�,�ִ�)] �ش� �Ӽ��� int �Ǵ� float�� �߰��� ���
    //����Ƽ �����Ϳ��� ��ũ���� ���� ��ġ�� ���� �� �� �ְ�,
    //�ش� ������ �ƴ� ���� ������ ������ �ּڰ��̳� �ִ밪���� �ٽ� �����ϴ� ���
    [Range(0,100)] public int volume;



}
