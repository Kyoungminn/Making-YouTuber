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
    public static int health = 100; //건강
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

    public static float sub_time = 0;

   
    //public bool chk_sub = true;
    //public bool chk_sub1 = true;
    //public bool chk_sub2 = true;
    //public bool chk_sub3 = true;

    public static GameObject GMS;
    public GameObject prefabDownSubPop;

    void Awake()
    {
        GMS = GameObject.Find("GameManagerScript");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("gameManager");
        if (objs.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Debug.Log("시작");
    }

    void Update()
    {
        if (uploadChkMain == true) //업로드하면 구독자 수 증가 실행
        {
            CancelInvoke("down_subscriber");
            if (subscriber > 1000) CancelInvoke("up_subscriber");
            uploadChkMain = false;
            StartCoroutine(Up_subscriberStart()); //유투바버튼 받는거 기다려야하므로 코루틴함수로 실행
        }

        if(!uploadChkMain && sub_time <= 600f && sub_time >= 0f) sub_time += Time.deltaTime;

        //실버버튼 이상부터 10분이 지나면 증가가 멈추고 매일 감소 시작 
        string yb = youtubaButton;
        if (!yb.Equals("") && !yb.Equals("bronze") && (int)sub_time == 600 && !uploadChkMain) 
        {
            sub_time = -1; //한번만 실행되도록 하기 위해
            InvokeRepeating("down_subscriber", 0.01f, 60f);
            Debug.Log("구독자수감소시작");
        }
    }

    IEnumerator Up_subscriberStart()
    {
        yield return null; //한 프레임 기다림
        string btName = youtubaButton;
        Debug.Log(btName + "구독자증가");
        float tm;
        if (btName.Equals(button_name[0])) tm = 10f;
        else if (btName.Equals(button_name[1])) tm = 20f;
        else tm = 30f;
        InvokeRepeating("up_subscriber", tm, tm);
        sub_time = 0;
    }

    void up_subscriber() 
    {
        if (youtubaButton == button_name[3] || youtubaButton == button_name[4])
        {
            subscriber += 5 * (subscriber / 1000);
            Debug.Log("골드이상구독자 수 증가" + subscriber);
        }
        else
        {
            subscriber += subscriber / 100;
            Debug.Log("구독자 수 증가" + subscriber);
        }
        Debug.Log(sub_time);

    }
    
    void down_subscriber() 
    {
        subscriber -= 5 * (subscriber/100);
        Debug.Log("구독자 수 감소"+　subscriber);
        Debug.Log(sub_time);

        //팝업창 뜨게하기
        SoundManager._soundInstance.PopupAudio();
        GameObject par = GameObject.Find("Canvas");
        GameObject child = Instantiate(prefabDownSubPop) as GameObject;
        child.transform.SetParent(par.transform);
        child.transform.localPosition = new Vector3(0f, 0f, 0f);
        child.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }
    

}