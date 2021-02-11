using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int game_year = DateTime.Now.Year;
    public static int game_month = 1; //1월부터 12월
    public static float game_day = 1.0f; //1일부터 31일, 사용할 때 int로 바꿔서 사용하시면 됩니다!
    public static float game_time = 0.0f; //게임 시간, 단위는 게임상에서 몇 일 ex) game_time 값이 1이면 1일인 것

    public static string human_name; //사람이름
    public static string channel_name; //채널이름

    public static string nickname; //구독자 애칭

    public static int money; //돈
    public static int health; //건강
    public static int charm; //매력
    public static int edit; //편집


    public static int subscriber = 100; //구독자수
    public static string youtubaButton = ""; //현재 유저가 지닌 최고 버튼
    public static string now_membership = ""; //유저가 선택한 멤버십 버튼 종류
    public static List<string> button_name = new List<string>{"bronze","silver", "gold", "diamond","ruby"}; //브론즈,실버,골드,다이아,루비

    public static bool uploadChkLocker; //보관함에서 동영상업로드 여부 확인
    public static bool uploadChkMain; //메인에서 동영상 업로드 후 시간재기 위해 쓸 변수

    //엔딩위한 컨셉개수저장;
    public static int[] conceptCnt = new int[8];
    public static Dictionary<string, int> EndingConcept = new Dictionary<string, int>{ {"토킹",0},{"게임",1},{"먹방",2},{"요리",3},{"브이로그",4},{"ASMR",5},{"노래",6},{"유행",7} };

    public GameObject UploadPanel;

    public static float sub_time = 0;

    public bool chk_sub = true;
    public bool chk_sub1 = true;
    public bool chk_sub2 = true;

    void Start()
    {
      
        
    }

    void Update()
    {
            if (uploadChkMain == true && chk_sub) //업로드하면 30초 간격으로 구독자 수 증가
            {
                chk_sub = false;
                InvokeRepeating ("up_subscriber", 30 ,30);
                sub_time = 0;
            }

            sub_time += Time.deltaTime;

            if(sub_time >= 600 && chk_sub1) //10분이 지나면 증가가 멈추고 10분 간격으로 감소 시작 
            {
                chk_sub1 = false;    
                CancelInvoke("up_subscriber");
                Debug.Log("현재구독자수 :" + subscriber);
                uploadChkMain = false;
      
            }

            if (uploadChkMain == false && chk_sub2)
            {
                chk_sub2 = false;
                InvokeRepeating ("down_subscriber", 600 ,600); //아니면 10분 간격으로 구독자 수 감소
    
            }
        
        
    
    }

    void change_sub()
    {
    

    }
    void up_subscriber() 
    {
        subscriber += subscriber/100;
        Debug.Log("구독자 수 증가"+ subscriber);

    }
    void down_subscriber() 
    {
        subscriber -= 5 * (subscriber/100);
        Debug.Log("구독자 수 감소"+　subscriber);

    }
    

}