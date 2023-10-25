using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// 자식 오브젝트로 보드를 가지고 있는 오브젝트에 연결합니다.
/// </summary>
[RequireComponent(typeof(AudioClip))]
public class SoundVisualizer : MonoBehaviour
{
    public float min_height = 15f;
    public float max_height = 300f;

    public Color board_color = Color.magenta;

    public float t = 10f;

    public Image[] boards;

    public AudioClip audioClip;
    public bool loop = true;

    private AudioSource audioSource;
    //public AudioMixer audioMixer;

    [Range(64, 8192)] public int Simples = 64;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();

        audioSource.loop = loop;
        audioSource.clip = audioClip;
        //audioSource.outputAudioMixerGroup = audioMixer.outputAudioMixerGroup;
        audioSource.Play();

        boards = GetComponentsInChildren<Image>();

        for (int i = 0; i < boards.Length; i++)
        {
            boards[i].GetComponent<Image>().color = board_color;
        }
    }

    void Update()
    {
        float[] spectrumData = audioSource.GetSpectrumData(Simples, 0, FFTWindow.Rectangular);

        for (int i = 0; i < boards.Length; i++)
        {
            RectTransform rect = boards[i].GetComponent<RectTransform>();
            Vector2 newSize = rect.rect.size;

            newSize.y = Mathf.Clamp(
                Mathf.Lerp(newSize.y, min_height + (spectrumData[i] * (max_height - min_height)) * 5f, t * 5.0f),
                min_height, max_height);
            rect.sizeDelta = newSize;
        }
    }
}