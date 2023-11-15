using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BGMType
{
    None,       //����
    Title,      //Ÿ��Ʋ
    InGame,     //���� ��
    InBoss,     //������
}
//SE ����
public enum SEType
{
    GameClear,  //���� Ŭ����
    GameOver,   //���� ����
    Shoot,      //Ȱ ���
}
public class SoundManager : MonoBehaviour
{
    public AudioClip bgmInTitle;    //Ÿ��Ʋ BGM
    public AudioClip bgmInGame;     //���� �� BGM
    public AudioClip bgmInBoss;     //������ BGM

    public AudioClip meGameClear;   //���� Ŭ����
    public AudioClip meGameOver;    //���� ����
    public AudioClip seShoot;       //Ȱ ���

    public static SoundManager soundManager;    //ù SoundManager�� ���� ����
    public static BGMType plyingBGM = BGMType.None;    //��� ���� BGM

    private void Awake()
    {
        //BGM ���
        if (soundManager == null)
        {
            soundManager = this;  //static ������ �ڱ� �ڽ��� ����
                                  //���� �ٲ� ���� ������Ʈ�� �ı����� ����
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);//���� ������Ʈ�� �ı�
        }
    }
    public void PlayBgm(BGMType type)
    {
        if (type != plyingBGM)
        {
            plyingBGM = type;
            AudioSource audio = GetComponent<AudioSource>();
            if (type == BGMType.Title)
            {
                audio.clip = bgmInTitle;    //Ÿ��Ʋ
            }
            else if (type == BGMType.InGame)
            {
                audio.clip = bgmInGame;     //���� ��
            }
            else if (type == BGMType.InBoss)
            {
                audio.clip = bgmInBoss;     //������
            }
            audio.Play();
        }
    }
    public void StopBgm()
    {
        GetComponent<AudioSource>().Stop();
        plyingBGM = BGMType.None;
    }
    public void SEPlay(SEType type)
    {
        if (type == SEType.GameClear)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameClear);   //���� Ŭ����
        }
        else if (type == SEType.GameOver)
        {
            GetComponent<AudioSource>().PlayOneShot(meGameOver);   //���� ����
        }
        else if (type == SEType.Shoot)
        {
            GetComponent<AudioSource>().PlayOneShot(seShoot);       //Ȱ ���
        }
    }

}
