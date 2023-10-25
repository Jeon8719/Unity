using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer audioMixer; 
    public Slider BGM_Slider;
    public Slider SFX_Slider;


    // Start is called before the first frame update
    void Start()
    {
        //최소 값 설정
        BGM_Slider.minValue = -40;
        SFX_Slider.minValue = -40;
        //슬라이더에 기능 추가
        BGM_Slider.onValueChanged.AddListener(AudioControl);
        SFX_Slider.onValueChanged.AddListener(AudioControl2);
        //BGM_Slider.onValueChanged.AddListener(delegate {AudioControl(BGM_Slider.value,"BGM");});
        //BGM_Slider.onValueChanged.AddListener(delegate {AudioControl(BGM_Slider.value,"SFX");});
    }

    public void AudioControl2(float sound)
    {
        if (sound == -40)
        {
            audioMixer.SetFloat("SFX", -80);
            //오디오믹서의 BGM 피라미터를 가지는 값의 수치를 -80으로 설정
        }
        else
        {
            audioMixer.SetFloat("SFX", sound);
        }
    }

    public void AudioControl(float sound)// (float sound, string paras)
    {
        if(sound == -40)
        {
            audioMixer.SetFloat("BGM", -80);
            //오디오믹서의 BGM 피라미터를 가지는 값의 수치를 -80으로 설정
        }
        else
        {
            audioMixer.SetFloat("BGM", sound);
            //audioMixer.SetFloat(paras, sound);
        }

    }

    public void SoundControl()
    {

    }
}
