using System;
using System.Collections.Generic;
using UnityEngine;
//2023-10-17 SoundManager 틀 추가
//2023-10-23 ManagerSystem을 통해 리소스를 로드하는 기능 추가
/// <summary>
/// 소리에 대한 구분 데이터
/// </summary>
public enum Sound
{
    BGM, SFX
}

public class SoundManager : MonoBehaviour
{
    #region Components
    AudioSource[] _audioSources = new AudioSource[2];
    Dictionary<string, AudioClip> audioclips = new Dictionary<string, AudioClip>();
    //Dicitionary는 키와 값을 쌍으로 저장하는 자료 구조
    //키를 통해 값을 접근
    //현재 딕셔너리의 키는 string의 형태로 실행할 음악의 이름을 표현
    //키를 통해 접근할 값은 AudioClip 형태의 데이터로 실행할 음악 파일을 의미.

    //AudioClip : 유니티 내에서 음악 파일에 대한 것은 이 오디오 클립 형태로 다룬다.
    #endregion

    private void Start()
    {
        lnit();
    }

    /// <summary>
    /// 사운드 매니저를 초기화할 떄 호출하는 함수
    /// </summary>
    public void lnit()
    {
        GameObject root = GameObject.Find("Sound");
        //Sound 객체를 찾고 없으면 오브젝트 이름을 Sound로 하나 새로 생성
        if (root == null)
        {

            root = new GameObject { name = "Sound" };

            //씬을 이동해도 파괴되지 않는다.
            DontDestroyOnLoad(root);

            //사용할 사운드의 처리
            string[] sounds = Enum.GetNames(typeof(Sound));
            //Enum으로 이름을 얻는다. BGM,SFX

            //사운드 수만큼 반복
            for (int i = 0; i < sounds.Length; i++)
            {
                GameObject go = new GameObject(name = sounds[i]);
                //new 클래스명 {클래스의 필드 값에 대한 초기화 };
                _audioSources[i] = go.AddComponent<AudioSource>();
                //게임 오브젝트에 AudioSource 컴포넌트 추가
                go.transform.parent = root.transform;
                //게임 오브젝트의 부모(상위 개체)는 root로 설정

            }
            //BGM은 계속 재생
            _audioSources[(int)Sound.BGM].loop = true;



        }
    }
    /// <summary>
    /// 
    /// 오디오 클립을 추가로 얻어오는 기능
    /// </summary>
    /// <param name="path">경로에 대해 작성</param>
    /// <param name="type">사운드 효과 작성, 따라 작성하지 않으면 SFX로 인식</param>
    /// <returns></returns>
    AudioClip SetAudioClip(string path, Sound type = Sound.SFX)
    {
        //프로젝트에서 지정한 폴더 위치로 저장되게 경로 설정
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip _clip = null; //작업시 사용할 오디오 클립에 대한 표현(1개)

        //넘겨받은 타입에 따라 값 설정
        switch (type)
        {
            //사운드가 BGM일 경우

            case Sound.BGM:
                // 매니저를 관리하는 코드로부터 경로의 값을 통해 오디오 클립을 로드



                break;



            //사운드가 SFX일 경우
            case Sound.SFX:
                // 매니저를 관리하는 코드로부터 경로의 값을 통해 오디오 클립을 로드
                //해당 클립을 오디오 클립에 추가

                break;
        }


        return _clip;

    }
}
