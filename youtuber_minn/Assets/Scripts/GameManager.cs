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
    public static string now_membership; //유저가 선택한 멤버십 버튼 종류
    public static List<string> button_name = new List<string>{"","bronze","silver", "gold", "diamond","ruby"}; //노버튼,브론즈,실버,골드,다이아,루비
    public static List<int> statMaximum = new List<int> {100, 300, 500, 700, 1000}; //버튼마다 스탯 최대치
                                                    //노버튼 브론즈 실버 골드 다이아

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
    public bool chk_sub3 = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (youtubaButton == button_name[0] && chk_sub3) //노버튼일때
        {
            chk_sub3 = false;

            if (uploadChkMain == true && chk_sub) //업로드하면 10초 간격으로 구독자 수 증가
            {
                chk_sub = false;
                InvokeRepeating ("up_subscriber", 10 ,10);
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
        
        if (subscriber >= 10000 && charm >= 100 && !chk_sub3) //브론즈일때
        {
            chk_sub3 = true;
            youtubaButton = button_name[1];

            if (uploadChkMain == true && chk_sub) //업로드하면 10초 간격으로 구독자 수 증가
            {
                chk_sub = false;
                InvokeRepeating ("up_subscriber", 20 ,20);
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

        if (subscriber >= 100000 && charm >= 300 && chk_sub3) //실버일때
        {
            chk_sub3 = false;
            youtubaButton = button_name[2];
            
            if (uploadChkMain == true && chk_sub) //업로드하면 10초 간격으로 구독자 수 증가
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

        if (subscriber >= 1000000 && charm >= 500 && !chk_sub3) //골드 이상일때
        {
            chk_sub3 = true;
            youtubaButton = button_name[3];
            
            if (uploadChkMain == true && chk_sub) //업로드하면 10초 간격으로 구독자 수 증가
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

        if (subscriber >= 10000000 && charm >= 700 && chk_sub3)
        {
            chk_sub3 = false;
            youtubaButton = button_name[4];
          
        }
        if (subscriber >= 50000000 && charm >= 1000 && !chk_sub3)
        {
            chk_sub3 = true;
            youtubaButton = button_name[5];

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