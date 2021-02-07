using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip gameBgm; //bgm
    public AudioClip clendarRandomPopupAudio; //일정,랜덤이벤트 창 효과음
    public AudioClip shopPayAudio; //상점 구매 효과음
    public AudioClip buttonAudio; //버튼음

    public static SoundManager _soundInstance;

    // Start is called before the first frame update
    void Start()
    {
        _soundInstance = this;
        this.audio = gameObject.AddComponent<AudioSource>();
        this.audio.loop = false;
    }

    public void OnButtonAudio()
    {
        audio.clip = buttonAudio;
        audio.volume = 0.6f;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
