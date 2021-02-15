using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static GameObject Bgm;
    public static AudioSource bgm;
    void Awake()
    {
        
            //GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
            //if (objs.Length > 1)
               // Destroy(this.gameObject);

           // DontDestroyOnLoad(this.gameObject);
        

        Bgm = GameObject.Find("BGM");
        bgm = Bgm.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (bgm.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        {
            bgm.Play();
            DontDestroyOnLoad(Bgm); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)
        }


    }

}
