using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetData : MonoBehaviour
{
    public GameObject effectOn, effectOff, backOn, backOff;
    public static int profileIdx = 2;

    // Start is called before the first frame update
    void Start()
    {

        GameObject Bgm = GameObject.Find("BGM");
        AudioSource bgm = Bgm.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (bgm.isPlaying)
        {
            backOn.SetActive(true);
            backOff.SetActive(false);
        }
        else
        {
            backOff.SetActive(true);
            backOn.SetActive(false);
        }

        if (SoundManager.EffectAudioChk)
        {
            effectOn.SetActive(true);
            effectOff.SetActive(false);
        }
        else
        {
            effectOff.SetActive(true);
            effectOn.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BackGroundMusicOffButton() //배경음악 키고 끄는 버튼
    {
        GameObject Bgm = GameObject.Find("BGM");
        AudioSource bgm = Bgm.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (bgm.isPlaying) bgm.Stop();
        else bgm.Play();
    }
}
