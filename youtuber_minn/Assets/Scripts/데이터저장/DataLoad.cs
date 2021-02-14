using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class DataLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //데이터 불러오기
        DataController.Instance.LoadGameData();
        GameManager.game_year = DataController.Instance._gameData.GM_game_year;
        GameManager.game_month = DataController.Instance._gameData.GM_game_month;
        GameManager.game_day = DataController.Instance._gameData.GM_game_day;
        GameManager.game_time = DataController.Instance._gameData.GM_game_time;
        GameManager.sub_time = DataController.Instance._gameData.GM_sub_time;
        GameManager.human_name = DataController.Instance._gameData.GM_human_name;
        GameManager.channel_name = DataController.Instance._gameData.GM_channel_name;
        GameManager.nickname = DataController.Instance._gameData.GM_nickname;
        GameManager.health = DataController.Instance._gameData.GM_health;
        GameManager.charm = DataController.Instance._gameData.GM_charm;
        GameManager.edit = DataController.Instance._gameData.GM_edit;
        GameManager.money = DataController.Instance._gameData.GM_money;
        GameManager.subscriber = DataController.Instance._gameData.GM_subscriber;
        GameManager.youtubaButton = DataController.Instance._gameData.GM_youtubaButton;
        GameManager.now_membership = DataController.Instance._gameData.GM_now_membership;
        GameManager.uploadChkLocker = DataController.Instance._gameData.GM_uploadChkLocker;
        GameManager.uploadChkMain = DataController.Instance._gameData.GM_uploadChkMain;
        GameManager.membershipChk = DataController.Instance._gameData.GM_membershipChk;
        for(int i = 0; i < 8; i++)
        {
            GameManager.conceptCnt[i] = DataController.Instance._gameData.GM_conceptCnt[i];
        }

        //GameTime
        GameTime.tutorialChk = DataController.Instance._gameData.GT_tutorialChk;
        GameTime.monthChange = DataController.Instance._gameData.GT_monthChange;
        for (int i = 0; i <= 31; i++)//매달 일에 들어가는 일정
        {
            GameTime.dayEvent[i] = DataController.Instance._gameData.GT_dayEvent[i];
            if (GameTime.dayEvent[i] != "" && GameTime.dayEvent[i] != "커뮤니티 글 작성") //매달에 대한 이벤트 존재 여부 및 몇 일에 있는지 저장
            {
              //  if(!GameTime.eventDay.ContainsKey(GameTime.dayEvent[i]))
                    GameTime.eventDay.Add(GameTime.dayEvent[i], i);
            }

            GameTime.videoCalendar[i] = DataController.Instance._gameData.GT_videoCalendar[i]; //동영상 업로드 후 일정에 저장
            GameTime.liveCalendar[i] = DataController.Instance._gameData.GT_liveCalendar[i];//라이브 후 일정에 저장
        }
        GameTime.cummunity = DataController.Instance._gameData.GT_cummunity.ToList(); //커뮤니티
        GameTime.healthPreday = DataController.Instance._gameData.GT_healthPreday;

        //Upload_sceneManager
        Upload_sceneManager.uploadThumnail_r = DataController.Instance._gameData.UM_uploadThumnail_r.ToList(); //썸네일 배경
        Upload_sceneManager.uploadThumnail_g = DataController.Instance._gameData.UM_uploadThumnail_g.ToList(); //썸네일 배경
        Upload_sceneManager.uploadThumnail_b = DataController.Instance._gameData.UM_uploadThumnail_b.ToList(); //썸네일 배경
        Upload_sceneManager.uploadThumnailImage = DataController.Instance._gameData.UM_uploadThumnailImage.ToList();//썸네일
        Upload_sceneManager.uploadTitles = DataController.Instance._gameData.UM_uploadTitles.ToList(); //동영상 제목
        Upload_sceneManager.uploadHits = DataController.Instance._gameData.UM_uploadHits.ToList(); //동영상조회수
        Upload_sceneManager.uploadConcepts = DataController.Instance._gameData.UM_uploadConcepts.ToList(); //동영상 컨셉
        Upload_sceneManager.uploadAds = DataController.Instance._gameData.UM_uploadAds.ToList(); //동영상 광고개수
        Upload_sceneManager.uploadPayoffs = DataController.Instance._gameData.UM_uploadPayoffs.ToList(); //동영상 총수익

        //DayEventController
        DayEventController.prevDay = DataController.Instance._gameData.DC_prevDay; //일정뜨게하기 위한 이전 날짜
        DayEventController.prevMonth = DataController.Instance._gameData.DC_prevMonth; //일정 뜨게 하기 위한 이전 달

        //VideoUploadTime
        VideoUploadTime.afterUploadTime = DataController.Instance._gameData.VT_afterUploadTime; //동영상 업로드 후 시간
        VideoUploadTime.afterLiveTime = DataController.Instance._gameData.VT_afterLiveTime; //라이브 방송 후 시간

        //ItemLocker
        for (int i = 0; i < 30; i++)
        {
            if(i < 4)
            {
                ItemLocker.HealthItems[i, 0] = DataController.Instance._gameData.IL_HealthItems_0[i];
                ItemLocker.HealthItems[i, 1] = DataController.Instance._gameData.IL_HealthItems_1[i];
                ItemLocker.HealthItems[i, 2] = DataController.Instance._gameData.IL_HealthItems_2[i];
            }
            if(i < 6)
            {
                ItemLocker.Index[i] = DataController.Instance._gameData.IL_Index[i];
            }

            ItemLocker.CharmItems[i, 0] = DataController.Instance._gameData.IL_CharmItems_0[i];
            ItemLocker.CharmItems[i, 1] = DataController.Instance._gameData.IL_CharmItems_1[i];
            ItemLocker.CharmItems[i, 2] = DataController.Instance._gameData.IL_CharmItems_2[i];

            ItemLocker.EditItems[i, 0] = DataController.Instance._gameData.IL_EditItems_0[i];
            ItemLocker.EditItems[i, 1] = DataController.Instance._gameData.IL_EditItems_1[i];
            ItemLocker.EditItems[i, 2] = DataController.Instance._gameData.IL_EditItems_2[i];
        }

        //RandomEvent
        RandomEvent_appear.Time_before = DataController.Instance._gameData.RE_Time_before;

        //LiveBroadcast
        LiveBroadcast.firstLive = DataController.Instance._gameData.LB_firstLive;

        //EndingController
        EndingController.gameEnding = DataController.Instance._gameData.EC_gameEnding.ToList();
        EndingController.gameEnding_name = DataController.Instance._gameData.EC_gameEnding_name.ToList();
        EndingController.gameEnding_channel = DataController.Instance._gameData.EC_gameEnding_channel.ToList();
   
        Debug.Log(GameManager.game_time);
    }


}
