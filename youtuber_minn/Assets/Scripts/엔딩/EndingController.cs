using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public static List<int> gameEnding = new List<int>();
    public static List<string> gameEnding_name = new List<string>();
    public static List<string> gameEnding_channel = new List<string>();

    public Text channelTxt, endingHit;
    float endinghits = 0;
    public int endingIdx = 0;
    int endingMax = 0, endingMin = 100000000;

    public Image endGraphic;
    public Text endText;
    string endPublicText;
    public Sprite[] endingGraphics = new Sprite[9]; 
    //토킹0,게임1,먹방2,요리3,브이로그4,ASMR5,노래6,유행7,PD8 

    // Start is called before the first frame update
    void Start()
    {
        channelTxt.text = GameManager.channel_name;

        for(int i=0;i<8;i++)
        {
            if(endingMax < GameManager.conceptCnt[i])
            {
                endingMax = GameManager.conceptCnt[i];
                endingIdx = i;
            }
            if(endingMin > GameManager.conceptCnt[i])
            {
                endingMin = GameManager.conceptCnt[i];
            }
        }

        if(endingMax - endingMin <= 3)
        {
            endingIdx = 8;
        }

        endGraphic.sprite = endingGraphics[endingIdx];

        endPublicText = "구독자 100명으로 시작했던 " + GameManager.channel_name + "은/는 어느새 구독자 5천만 명을 넘겨 루비 버튼을 받게 되었다.";
        switch(endingIdx)
        {
            case 0:
                endText.text = endPublicText + "\n토크 방송으로 유명했던 " + GameManager.channel_name + 
                    "채널 주인 " + GameManager.human_name + 
                    "은/는 엄청난 러브콜을 받고 모든 연예인들이 함께 출현하고 싶어하는 국민MC라는 타이틀을 얻게 되었다.";
                break;
            case 1:
                endText.text = endPublicText + "\n게임 방송으로 유명했던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 루비버튼을 받고 프로게이머가 되어 억대 연봉을 받는 제2의 페이커가 되었다.";
                break;
            case 2:
                endText.text = endPublicText + "\n먹방으로 유명했던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 루비버튼을 받고 놀라운 일요일-파솔라마켓에서 햇님으로 활약하게 되었다.";
                break;
            case 3:
                endText.text = endPublicText + "\n요리 방송으로 유명했던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 루비버튼을 받고 세계 최고 호텔의 셰프가 되었다.";
                break;
            case 4:
                endText.text = endPublicText + "\n브이로그 영상으로 유명했던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 루비버튼을 받고 대형 기획사를 이끄는 기획사 사장이 되었다.";
                break;
            case 5:
                endText.text = endPublicText + "\n꾸준히 ASMR 영상을 올려 수면을 유도하던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 루비버튼을 받고 사람을 재우는 수면전문의가 되었다.";
                break;
            case 6:
                endText.text = endPublicText + "\n노래 실력으로 유명했던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 루비버튼을 받고 잠실주경기장에서 콘서트를 하는 가수가 되었다.";
                break;
            case 7:
                endText.text = endPublicText + "\n트렌드란 트렌드는 전부 시도하던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 루비버튼을 받고 유행을 이끄는 인플루언서가 되었다.";
                break;
            default:
                endText.text = endPublicText + "\n다양한 영상을 다루던 " + GameManager.channel_name +
                    "채널 주인 " + GameManager.human_name +
                    "은/는 대한민국 최고의 PD가 되었다.";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(endingHit.gameObject.activeSelf == true)
        {
            endinghits += (Time.deltaTime * 10000.0f);
            if(endinghits > 10000f)
            {
                endingHit.text = string.Format("{0:0.0}", endinghits / 10000f) + "만 회";
            }
            else endingHit.text = ((int)endinghits).ToString() + "회";
        }
    }

    public void OnFinButtonClick()
    {
        gameEnding.Add(endingIdx);
        gameEnding_name.Add(GameManager.human_name);
        gameEnding_channel.Add(GameManager.channel_name);

        //초기화
        GameManager.game_year = DateTime.Now.Year;
        GameManager.game_month = 1;
        GameManager.game_day = 1.0f;
        GameManager.game_time = 0.0f;
        GameManager.sub_time = 0f;
        GameManager.human_name = "";
        GameManager.channel_name = "";
        GameManager.nickname = "";
        GameManager.health = 0;
        GameManager.charm = 0;
        GameManager.edit = 0;
        GameManager.money = 0;
        GameManager.subscriber = 0;
        GameManager.youtubaButton = "";
        GameManager.uploadChkLocker = false;
        GameManager.uploadChkMain = false;
        for (int i = 0; i < 8; i++)
        {
            GameManager.conceptCnt[i] = 0;
        }

        //GameTime
        GameTime.tutorialChk = true;
        GameTime.monthChange = false;
        GameTime.dayEvent = new string[32]; //매달 일에 들어가는 일정 
        GameTime.videoCalendar = new bool[32]; //동영상 업로드 후 일정에 저장
        GameTime.liveCalendar = new bool[32]; //라이브 후 일정에 저장
        GameTime.eventDay = new Dictionary<string, int>();
        GameTime.cummunity = new List<int>(); //커뮤니티
        GameTime.healthPreday = 0;

        //Upload_sceneManager
        Upload_sceneManager.uploadThumnail_r = new List<float>(); //썸네일 배경
        Upload_sceneManager.uploadThumnail_g = new List<float>(); //썸네일 배경
        Upload_sceneManager.uploadThumnail_b = new List<float>(); //썸네일 배경
        Upload_sceneManager.uploadThumnailImage = new List<int>();//썸네일
        Upload_sceneManager.uploadTitles = new List<string>(); //동영상 제목
        Upload_sceneManager.uploadHits = new List<int>(); //동영상조회수
        Upload_sceneManager.uploadConcepts = new List<string>(); //동영상 컨셉
        Upload_sceneManager.uploadAds = new List<int>(); //동영상 광고개수
        Upload_sceneManager.uploadPayoffs = new List<int>(); //동영상 총수익

        //DayEventController
        DayEventController.prevDay = 0; //일정뜨게하기 위한 이전 날짜
        DayEventController.prevMonth = 0; //일정 뜨게 하기 위한 이전 달

        //VideoUploadTime
        VideoUploadTime.afterUploadTime = 0f; //동영상 업로드 후 시간
        VideoUploadTime.afterLiveTime = 0f; //라이브 방송 후 시간

        //ItemLocker
        for (int i = 0; i < 30; i++)
        {
            if (i < 4)
            {
                ItemLocker.HealthItems[i, 0] = 0;
                ItemLocker.HealthItems[i, 1] = 0;
                ItemLocker.HealthItems[i, 2] = 0;
            }
            if (i < 6)
            {
                ItemLocker.Index[i] = 0;
            }

            ItemLocker.CharmItems[i, 0] = 0;
            ItemLocker.CharmItems[i, 1] = 0;
            ItemLocker.CharmItems[i, 2] = 0;

            ItemLocker.EditItems[i, 0] = 0;
            ItemLocker.EditItems[i, 1] = 0;
            ItemLocker.EditItems[i, 2] = 0;
        }

        //RandomEvent
        RandomEvent_appear.Time_before = 0;

        SceneManager.LoadScene("Tutorial_scene");
    }
}
