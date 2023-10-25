using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://wonjuri.tistory.com/entry/unity-%EC%BB%A8%ED%85%8C%EC%9D%B4%EB%84%88-%EC%A0%9C%EC%9E%91-%EC%82%AC%EC%9A%B4%EB%93%9C-%ED%94%8C%EB%A0%88%EC%9D%B4%EC%96%B4-%EB%A7%8C%EB%93%A4%EA%B8%B01
namespace Container.Sound
{



    public class SoundPlayer : MonoBehaviour
    {
        public static SoundPlayer Instance { get; private set; }
        [SerializeField]
        protected AudioSource audio_bgm = null;
        [SerializeField]
        protected SoundObject audio_basic = null;
        [SerializeField]
        protected AudioClip[] arr_AudioEffectClip = null;
        protected List<SoundObject> List_Sound = new List<SoundObject>();
        protected Dictionary<SoundType, AudioClip> dic_EffectSound = new Dictionary<SoundType, AudioClip>();
        protected readonly string SOUND_NAME = "_Sound";
        protected readonly float BGM_VOLUM = 0.5f;
        private void Awake()
        {
            Instance = this;
            dic_EffectSound.Clear();
            List_Sound.Add(audio_basic);
            for (int i = 0; i < arr_AudioEffectClip.Length; i++)
            {
                dic_EffectSound.Add((SoundType)Enum.Parse(typeof(SoundType),
                    arr_AudioEffectClip[i].name), arr_AudioEffectClip[i]);
            }
        }

        /// <summary>
        /// MonoBehaviour가 파괴 되었을 때 호출하는 기능
        /// </summary>
        void OnDestroy()
        {
            Instance = null;
        }
        public bool IsBgmPlaying
        { get { return audio_bgm.isPlaying; } }

        /// <summary>
        /// 사운드 재생 여부 파악
        /// </summary>
        public bool IsPlaying()
        {
            foreach (SoundObject snd in List_Sound)
            {
                if (snd.IsPlaying)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsPause()
        {
            if(Time.timeScale <= 0)
                return true; return false;
        }
        /// <summary>
        /// 사운드 클릭 얻기
        /// </summary>
        /// <returns>The sound clip</returns>
        /// <param name="type">Common Sound Type</param>
        public AudioClip GetSoundClip(SoundType type)
        {
            if (dic_EffectSound.ContainsKey(type))
            {
                return dic_EffectSound[type];
            }
            else
                return null;
        }
        #region BGM
        public void PlayBGM(AudioClip clip)
        {
            PlayBGM(clip, BGM_VOLUM);
        }
        public void PlayBGM(AudioClip clip, float volume)
        {
            PlayBGM(clip, volume, true);
        }
        public void PlayBGM(AudioClip clip, float volum, bool isloop)
        {
            if (clip == null)
            {
                Debug.Log("BGM clip is null");
                return;
            }
            if (IsBgmPlaying)
            {
                audio_bgm.Stop();
            }
            audio_bgm.clip = clip;
            audio_bgm.volume = volum;
            audio_bgm.loop = isloop;
            audio_bgm.Play();
        }
        public void stopBGM()
        {
            audio_bgm.Stop();
        }
        public void PauseBGM()
        {
            if (audio_bgm.isPlaying)
                audio_bgm.Play();
        }
        public void UnpausBGM()
        {
            audio_bgm.UnPause();
        }
        #endregion


        #region PlaySound
        /// <summary>
        /// 사운드 플레이
        /// </summary>
        /// <param name="soundType">Sound type  </param>
        public void PlaySound(SoundType soundType)
        {
            PlaySound(soundType, true);
        }
        /// <summary>
        /// 사운드 플레이
        /// </summary>
        /// <param name="soundType">Sound type  </param>
        /// <param name="isStopEnable">If set to <c>true</c>is stop enable.  </param>
        public void PlaySound(SoundType soundType, bool isStopEnable)
        {
            if (soundType == SoundType.None) return;
            PlaySound(GetSoundClip(soundType), 1f, 0, false, isStopEnable, null);
        }
        public void PlaySound(SoundType soundType, float volume)
        {
            if (soundType == SoundType.None) return;
            PlaySound(GetSoundClip(soundType), volume, null);
        }
        public void PlaySound(AudioClip clip)
        {
            PlaySound(clip, null);

        }
        public IEnumerator CoPlaySound(AudioClip clip, float minWaitSec = 0.5f)
        {
            float waitSec = (clip != null && clip.length > minWaitSec) ? clip.length : minWaitSec;
            PlaySound(clip, null);
            yield return new WaitForSeconds(waitSec);
        }
        /// <summary>
        /// 사운드 재생
        /// 
        /// </summary>
        /// <param name="clip">Clip.</param>
        /// <param name="finishListener">Finish listener.</param>
        public void PlaySound(AudioClip clip, System.Action finishListener)
        {
            PlaySound(clip, 1f, finishListener);
        }
        /// <summary>
        /// 사운드 재생
        /// 
        /// </summary>
        /// <param name="clip">Audio Clip.</param>
        /// <param name="Volume">Audio Volume. 0 ~ 1</param>
        /// <param name="finishListener">Finish listener.</param>
        public void PlaySound(AudioClip clip, float volume, System.Action finishListener)
        {
            PlaySound(clip, volume, 0, false, finishListener);
        }
        /// <summary>
        /// 사운드 재생
        /// </summary>
        /// <param name="clip">Audio Clip.</param>
        /// <param name="Volume">Audio Volume. 0 ~ 1</param>
        /// <param name="delaySeconds">사운드 플레이 전 delay 초</param>
        /// <param name="finishListener">Finish listener.</param>
        public void PlaySound(AudioClip clip, float volume, float delaySeconds, System.Action finishListener)
        {
            PlaySound(clip, volume, delaySeconds, false, finishListener);
        }
        /// <summary>
        /// 사운드 재생
        /// </summary>
        /// <param name="clip">Audio Clip.</param>
        /// <param name="Volume">Audio Volume. 0 ~ 1</param>
        /// <param name="delaySeconds">사운드 플레이 전 delay 초</param>
        /// <param name="isloop">If set to <c>true</c>is loop.</param>
        /// <param name="finishListener">Finish listener.</param>
        public void PlaySound(AudioClip clip, float volume, float delaySeconds, bool isLoop, System.Action finishListener)
        {
            PlaySound(clip, volume, delaySeconds, isLoop, true, finishListener);

        }
        /// <summary>
        /// 사운드 재생
        /// </summary>
        /// <param name="clip">Audio Clip.</param>
        /// <param name="Volume">Audio Volume. 0 ~ 1</param>
        /// <param name="delaySeconds">사운드 플레이 전 delay 초</param>
        /// <param name="isloop">If set to <c>true</c>is loop.</param>
        /// <param name="isStopEnable">If set to <c>true</c>is stop enable.</param>/// 
        /// <param name="finishListener">Finish listener.</param>
        public void PlaySound(AudioClip clip, float volume, float delaySeconds, bool isLoop, bool isStopEnable, System.Action finishListener)
        {
            if (clip == null)
            {
                Debug.Log("Sound Clip is Null");
                return;
            }
            if (IsPlaying() || IsPause())
            {
                SoundObject obj_Sound = CreateSoundObject(clip);
                List_Sound.Add(obj_Sound);
                obj_Sound.Play(volume, delaySeconds, isLoop, isStopEnable, () =>
                {
                    List_Sound.Remove(obj_Sound);
                    if (finishListener != null)
                        finishListener();

                });

            }
            else
            {
                audio_basic.Clip = clip;
                audio_basic.Play(volume, delaySeconds, isLoop, isStopEnable, () =>
                {
                    if (finishListener != null)
                        finishListener();
                });
            }
        }

        #endregion
        ///<summary>
        ///Unpauses all sound.
        /// </summary>
        public void UnpauseAllSound(bool includeBGM = true)
        {
            foreach (SoundObject snd in List_Sound)
            {
                snd.UnPause();
            }
            if (includeBGM)
                audio_bgm.UnPause();
        }
        ///<summary>
        ///Pauses all sound.
        /// </summary>
        public void PauseAllSound(bool includeBGM = true)
        {
            Debug.Log("Pause All Sound");
            foreach (SoundObject snd in List_Sound)
            { snd.Pause(); }
            if (includeBGM)
                audio_bgm.Pause();
        }

        ///<summary>
        ///Stops the sound.
        /// </summary>
        ///<returns><c>true</c>, if sound was stoped, <c>false</c>otherwise.</returns>
        ///<param name="_clip">Clip.</param>
        public bool StopSound(AudioClip _clip)
        {
            for (int i = 0; i < List_Sound.Count; i++)
            {
                if (List_Sound[i].Clip == _clip)
                {
                    List_Sound[i].Stop();
                    if (i != 0)
                        List_Sound.Remove(List_Sound[i]);
                    return true;
                }
            }
            return false;
        }
            ///<summary>
            ///stops all sound.
            ///배경음은 stop 제외
            /// </summary>
            /// <returns><c>true</c>, if all sound was stopped, <c>false</c> otherwise.</returns>
           
        public bool StopAllSound()
        {
            return StopAllSound(false);
        }
        ///<summary>
        ///stops all sound.
        /// </summary>
        ///<returns><c>true</c>, 배경음 포함 모든 사운드 제거 <c>false</c> 배경음 제외 모든 사운드 제거.</returns>
        ///<param name="includeBGM">If set to <c>true</c>include bgm</param>
        public bool StopAllSound(bool includeBGM)
        {
            foreach (SoundObject snd in List_Sound)
            {
                snd.Stop();
            }
            if (!includeBGM)
                audio_bgm.Stop();
            ClearAllSound();
            return true;
        }
        ///<summary>
        ///Clears all sound.
        ///</summary>
        protected void ClearAllSound()
        {
            List_Sound.Clear();
            List_Sound.Add(audio_basic);
        }
        ///<summary>
        ///사운드 객체를 생성하여 리턴
        ///</summary>
        ///<param name="clip">Audio Clip</param>
        ///<returns></returns>
        protected SoundObject CreateSoundObject(AudioClip _clip)
        {
            GameObject _soundOBJ = new GameObject(SOUND_NAME);
            _soundOBJ.transform.SetParent(audio_basic.transform);
            SoundObject snd = _soundOBJ.AddComponent<SoundObject>();
            snd.Clip = _clip;
            return snd;
        }







    }
}


