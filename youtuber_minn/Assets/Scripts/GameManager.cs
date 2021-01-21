using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string human_name; //사람이름
    public static string channel_name; //채널이름

    public static int money; //돈
    public static int health; //건강
    public static int charm; //매력
    public static int edit; //편집


    public static int subscriber; //구독자수
    public static List<string> button_name = new List<string>{"bronze","silver","diamond","ruby"}; //브론즈,실버,골드,다이아,루비

    public static bool uploadChkLocker = false; //보관함에서 동영상업로드 여부 확인
    public static bool uploadChkMain = false; //메인에서 동영상 업로드 후 시간재기 위해 쓸 변수


    public GameObject UploadPanel;

    void Start()
    {
        
    }

    void Update()
    {
    
    }
}