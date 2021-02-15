using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static bool EffectAudioChk = true; //이게 트루일 시 효과음 재생
    public new AudioSource audio;
    public AudioClip gameBgm; //bgm
    public AudioClip popupAudio; //일정,랜덤이벤트 창 효과음
    public AudioClip shopPayAudio; //상점 구매 효과음
    public AudioClip buttonAudio; //버튼음
    public AudioClip keyAudio; //타자치는소리

    public static SoundManager _soundInstance;

    void Awake()
    {
        _soundInstance = this;
    }

    void Start()
    {
        this.audio = gameObject.AddComponent<AudioSource>();
        this.audio.loop = false;
    }

    public void OnButtonAudio()
    {
        if(EffectAudioChk)
        {
            audio.clip = buttonAudio;
            audio.volume = 0.4f;
            audio.Play();
        }
        
    }

    public void OnShopPayAudio()
    {
        if (EffectAudioChk)
        {
            audio.clip = shopPayAudio;
            audio.volume = 0.5f;
            audio.Play();
        }
        
    }

    public void PopupAudio()
    {
        if (EffectAudioChk)
        {
            audio.clip = popupAudio;
            audio.volume = 0.8f;
            audio.Play();
        }
        
    }

    public void KeyboardAudio()
    {
        if (EffectAudioChk)
        {
            audio.clip = keyAudio;
            audio.volume = 0.03f;
            audio.Play();
        }

    }

    public void AudioOn()
    {
        EffectAudioChk = true;
    }

     public void AudioOff()
    {
        EffectAudioChk = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
