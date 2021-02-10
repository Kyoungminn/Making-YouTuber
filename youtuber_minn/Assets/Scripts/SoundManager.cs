using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip gameBgm; //bgm
    public AudioClip popupAudio; //일정,랜덤이벤트 창 효과음
    public AudioClip shopPayAudio; //상점 구매 효과음
    public AudioClip buttonAudio; //버튼음

    public static SoundManager _soundInstance;

    private void Awake()
    {
        _soundInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.audio = gameObject.AddComponent<AudioSource>();
        this.audio.loop = false;
    }

    public void OnButtonAudio()
    {
        audio.clip = buttonAudio;
        audio.volume = 0.8f;
        audio.Play();
    }

    public void OnShopPayAudio()
    {
        audio.clip = shopPayAudio;
        audio.volume = 0.7f;
        audio.Play();
    }

    public void PopupAudio()
    {
        audio.clip = popupAudio;
        audio.volume = 0.8f;
        audio.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
