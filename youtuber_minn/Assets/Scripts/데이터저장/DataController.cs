using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;

public class DataController : MonoBehaviour
{
    //싱글톤
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if(!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    public string GameDataFileName = "youtubaData.json"; //이름 변경 절대 x

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
            }
            return _gameData;
        }
    }

    private void Start()
    {
        LoadGameData();
    }

    //저장된 게임 불러오기
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        //저장된 게임이 있다면
        if(File.Exists(filePath))
        {
            Debug.Log("불러오기 성공!");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        //저장된 게임이 없다면
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
            _gameData.GT_dayEvent.Initialize();
            _gameData.IL_CharmItems_0[0] = _gameData.IL_CharmItems_1[0] = _gameData.IL_CharmItems_2[0] = 1;
        }
        
    }

    //게임 저장하기
    public void SaveGameData()
    {
        //GameManager 데이터 저장
        gameData.GM_game_year = GameManager.game_year;
        gameData.GM_game_month = GameManager.game_month;
        gameData.GM_game_day = GameManager.game_day;
        gameData.GM_game_time = GameManager.game_time;
        gameData.GM_human_name = GameManager.human_name;
        gameData.GM_channel_name = GameManager.channel_name;
        gameData.GM_health = GameManager.health;
        gameData.GM_charm = GameManager.charm;
        gameData.GM_edit = GameManager.edit;
        gameData.GM_money = GameManager.money;
        gameData.GM_subscriber = GameManager.subscriber;
        gameData.GM_youtubaButton = GameManager.youtubaButton;
        gameData.GM_uploadChkLocker = GameManager.uploadChkLocker;
        gameData.GM_uploadChkMain = GameManager.uploadChkMain;
        for(int i=0;i<8;i++)
        {
            gameData.GM_conceptCnt[i] = GameManager.conceptCnt[i];
        }

        //GameTime
        gameData.GT_tutorialChk = GameTime.tutorialChk;
        gameData.GT_monthChange = GameTime.monthChange;
        for (int i = 0; i <= 31; i++)//매달 일에 들어가는 일정
        {
            gameData.GT_dayEvent[i] = GameTime.dayEvent[i];
            gameData.GT_videoCalendar[i] = GameTime.videoCalendar[i];
            gameData.GT_liveCalendar[i] = GameTime.liveCalendar[i];
        }
        gameData.GT_cummunity = GameTime.cummunity.ToList(); //커뮤니티는 매 달 4개씩 가능하므로 그거 처리

        //Upload_sceneManager
        gameData.UM_uploadThumnail_r = Upload_sceneManager.uploadThumnail_r.ToList(); //썸네일 배경
        gameData.UM_uploadThumnail_g = Upload_sceneManager.uploadThumnail_g.ToList(); //썸네일 배경
        gameData.UM_uploadThumnail_b = Upload_sceneManager.uploadThumnail_b.ToList(); //썸네일 배경
        gameData.UM_uploadThumnailImage = Upload_sceneManager.uploadThumnailImage.ToList();//썸네일
        gameData.UM_uploadTitles = Upload_sceneManager.uploadTitles.ToList(); //동영상 제목
        gameData.UM_uploadHits = Upload_sceneManager.uploadHits.ToList(); //동영상조회수
        gameData.UM_uploadConcepts = Upload_sceneManager.uploadConcepts.ToList(); //동영상 컨셉
        gameData.UM_uploadAds = Upload_sceneManager.uploadAds.ToList(); //동영상 광고개수
        gameData.UM_uploadPayoffs = Upload_sceneManager.uploadPayoffs.ToList(); //동영상 총수익

        //DayEventController
        gameData.DC_prevDay = DayEventController.prevDay; //일정뜨게하기 위한 이전 날짜
        gameData.DC_prevMonth = DayEventController.prevMonth; //일정 뜨게 하기 위한 이전 달

        //VideoUploadTime
        gameData.VT_afterUploadTime = VideoUploadTime.afterUploadTime; //동영상 업로드 후 시간
        gameData.VT_afterLiveTime = VideoUploadTime.afterLiveTime; //라이브 방송 후 시간

        //ItemLocker
        for (int i = 0; i < 30; i++)
        {
            if (i < 4)
            {
                gameData.IL_HealthItems_0[i] = ItemLocker.HealthItems[i, 0];
                gameData.IL_HealthItems_1[i] = ItemLocker.HealthItems[i, 1];
                gameData.IL_HealthItems_2[i] = ItemLocker.HealthItems[i, 2];
            }
            if (i < 6)
            {
                gameData.IL_Index[i] = ItemLocker.Index[i];
            }
            gameData.IL_CharmItems_0[i] = ItemLocker.CharmItems[i, 0];
            gameData.IL_CharmItems_1[i] = ItemLocker.CharmItems[i, 1];
            gameData.IL_CharmItems_2[i] = ItemLocker.CharmItems[i, 2];

            gameData.IL_EditItems_0[i] = ItemLocker.EditItems[i, 0];
            gameData.IL_EditItems_1[i] = ItemLocker.EditItems[i, 1];
            gameData.IL_EditItems_2[i] = ItemLocker.EditItems[i, 2];
        }

        //RandomEvent
        gameData.RE_Time_before = RandomEvent_appear.Time_before;
        //

        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        //이미 저장된 파일이 있다면 덮어쓰기
        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("저장완료");
        Debug.Log(gameData.GM_game_time);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

}
