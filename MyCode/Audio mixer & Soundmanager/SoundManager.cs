using System;
using System.Collections.Generic;
using UnityEngine;
//2023-10-17 SoundManager Ʋ �߰�
//2023-10-23 ManagerSystem�� ���� ���ҽ��� �ε��ϴ� ��� �߰�
/// <summary>
/// �Ҹ��� ���� ���� ������
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
    //Dicitionary�� Ű�� ���� ������ �����ϴ� �ڷ� ����
    //Ű�� ���� ���� ����
    //���� ��ųʸ��� Ű�� string�� ���·� ������ ������ �̸��� ǥ��
    //Ű�� ���� ������ ���� AudioClip ������ �����ͷ� ������ ���� ������ �ǹ�.

    //AudioClip : ����Ƽ ������ ���� ���Ͽ� ���� ���� �� ����� Ŭ�� ���·� �ٷ��.
    #endregion

    private void Start()
    {
        lnit();
    }

    /// <summary>
    /// ���� �Ŵ����� �ʱ�ȭ�� �� ȣ���ϴ� �Լ�
    /// </summary>
    public void lnit()
    {
        GameObject root = GameObject.Find("Sound");
        //Sound ��ü�� ã�� ������ ������Ʈ �̸��� Sound�� �ϳ� ���� ����
        if (root == null)
        {

            root = new GameObject { name = "Sound" };

            //���� �̵��ص� �ı����� �ʴ´�.
            DontDestroyOnLoad(root);

            //����� ������ ó��
            string[] sounds = Enum.GetNames(typeof(Sound));
            //Enum���� �̸��� ��´�. BGM,SFX

            //���� ����ŭ �ݺ�
            for (int i = 0; i < sounds.Length; i++)
            {
                GameObject go = new GameObject(name = sounds[i]);
                //new Ŭ������ {Ŭ������ �ʵ� ���� ���� �ʱ�ȭ };
                _audioSources[i] = go.AddComponent<AudioSource>();
                //���� ������Ʈ�� AudioSource ������Ʈ �߰�
                go.transform.parent = root.transform;
                //���� ������Ʈ�� �θ�(���� ��ü)�� root�� ����

            }
            //BGM�� ��� ���
            _audioSources[(int)Sound.BGM].loop = true;



        }
    }
    /// <summary>
    /// 
    /// ����� Ŭ���� �߰��� ������ ���
    /// </summary>
    /// <param name="path">��ο� ���� �ۼ�</param>
    /// <param name="type">���� ȿ�� �ۼ�, ���� �ۼ����� ������ SFX�� �ν�</param>
    /// <returns></returns>
    AudioClip SetAudioClip(string path, Sound type = Sound.SFX)
    {
        //������Ʈ���� ������ ���� ��ġ�� ����ǰ� ��� ����
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip _clip = null; //�۾��� ����� ����� Ŭ���� ���� ǥ��(1��)

        //�Ѱܹ��� Ÿ�Կ� ���� �� ����
        switch (type)
        {
            //���尡 BGM�� ���

            case Sound.BGM:
                // �Ŵ����� �����ϴ� �ڵ�κ��� ����� ���� ���� ����� Ŭ���� �ε�



                break;



            //���尡 SFX�� ���
            case Sound.SFX:
                // �Ŵ����� �����ϴ� �ڵ�κ��� ����� ���� ���� ����� Ŭ���� �ε�
                //�ش� Ŭ���� ����� Ŭ���� �߰�

                break;
        }


        return _clip;

    }
}
