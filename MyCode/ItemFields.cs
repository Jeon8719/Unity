using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 해당 스크립트는 유니티에서 사용하는 변수(필드)에 대한 내용을
/// 다루고 있습니다.
/// </summary>
public class UnityFields : MonoBehaviour
{
    //유니티에서 확인할 수 있는 접근 제한자
    //1.public : 유니티 에디터에서 직접 값을 접근 가능
    //2.private : 에디터에서 접근 불가
    //사용자는 직접 수정, 코드에 의한 처리에 따라 public과 private를 결정

    //유니티에서 다루는 기본 데이터
    [Header("스테이터스")]
    //인스펙터에 타이틀을 다는 기능
    //해당 기능은 프로젝트의 규모가 클수록 중요
    public int value;
    public float f_value;
    public string word;
    public bool isCheck;
    [Tooltip("능력에 대한 열거")] public TYPE type;
    

    //유니티에서 사용하는 enum
    public enum TYPE
    {
        FIRE, WATER, LEAF
    }
    //[Range(최소,최대)] 해당 속성을 int 또는 float에 추가할 경우
    //유니티 에디터에서 스크롤을 통해 수치를 조정 할 수 있고,
    //해당 범위가 아닌 값을 적으면 범위내 최솟값이나 최대값으로 다시 설정하는 기능
    [Range(0,100)] public int volume;



}
