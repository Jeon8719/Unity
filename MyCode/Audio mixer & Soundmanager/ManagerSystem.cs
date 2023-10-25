using UnityEngine;


//2023-10-17 ManagerSystem 틀 추가
//2023-10-23 ManagerSystem에 리소스를 로드하는 기능 추가

/// <summary>
/// 매니저들을 관리하는 시스템 코드
/// </summary>
public class ManagerSystem : MonoBehaviour
{
    //외부에서 접근 불가능한 매니저시스템 형태의 객체
    private static ManagerSystem sound_instance;
    //사운드매니저
    SoundManager sound_manager = new SoundManager();
    public static SoundManager SM { get { return Instance.sound_manager; } }


    //1. 매니저에 대한 프로퍼티를 생성.
    //프로퍼티는 클래스에 가지고 있는 값에 대한 접근 속성
    //이 프로퍼티는 매니저 시스템에 대한 프로퍼티
    static ManagerSystem Instance
    {
        get
        {
            Init();
            return sound_instance;
        }

        //프로퍼티에는 값을 적용하는 get과 값을 설정하는 set이 존재
        //매니저 시스템에 따로 설정할 값이 없기에 이 코드에서 set은 제외

    }
    /// <summary>
    /// 매니저 시스템을 사용하려고 할 떄, 호출될 함수
    /// </summary>
    static void Init()
    {
        if (sound_instance == null)
        {
            GameObject go = GameObject.Find("Manager System");
            //오브젝트가 없으면 생성
            if (go == null)
            {
                go = new GameObject { name = "Manager System" };
                go.AddComponent<ManagerSystem>();
            }
            //파괴되지 않도록 처리
            DontDestroyOnLoad(go);
            //사운드 객체에 만들어준 go로부터 매니저 시스템의 기능을 얻어옴
            sound_instance = go.GetComponent<ManagerSystem>();
            //사운드 객체에서 soundmanager를 통해 SoundManager.cs에서 만든 Init()호출
            sound_instance.sound_manager.lnit();


        }
    }
}
