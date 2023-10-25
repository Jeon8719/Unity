using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTester : MonoBehaviour
{
    /*PlyaerPrefs
     * 유니티 내부에 간단한 데이터를 저장 후 로드하는 용도로 만들어진 데이터
     * 게임의 설정, 진행 상태 등을 저장하는 용도로 사용
     * 
     * 특징)float, string ,int 데이터만 저장
     * 저장 기능 PlayerPrefs.SetFloat,SetInt,SetString("키 이름". 값);
     * 로그 기능 PlayerPrefs.GetFloat,GetInt,GetString("키 이름");
     * 해당 키 존재 여부 체크 PlayerPrefs.HasKey("키 이름") 
     * 
     * 키 삭제 PlayerPrefs.DeleteKey("키")
     *         PlayerPrefs.DeleteAll()
     * 
     * 현 상태를 저장합니다.
     * PlayerPrefs.Save()
     * 
     */
    public string id = "SK0714";
    public int pw = 1234;

    private void Start()
    {
        PlayerPrefs.SetString("ID", "SK0714"); //문자열 기록
        PlayerPrefs.SetInt("PASS", 1234);
        Register();
    }
    public void Register()
    {
        if(id.Equals(PlayerPrefs.GetString("ID")))
        {
            if(pw == PlayerPrefs.GetInt("PASS"))
            {
                Debug.Log("로그인 성공!");
            }
            else
            {
                Debug.Log("비밀번호가 틀렸습니다!");
            }
        }
        else
        {
            Debug.Log("아이디가 틀렸습니다!");
        }
    }
}
