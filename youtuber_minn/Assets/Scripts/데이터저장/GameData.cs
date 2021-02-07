using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class GameData
{
    //GameManager-OK
    public int GM_game_year = DateTime.Now.Year;
    public int GM_game_month = 1; //1월부터 12월
    public float GM_game_day = 1.0f; //1일부터 31일, 사용할 때 int로 바꿔서 사용하시면 됩니다!
    public float GM_game_time = 0.0f; //게임 시간, 단위는 게임상에서 몇 일 ex) game_time 값이 1이면 1일인 것
    public string GM_human_name = ""; //사람이름
    public string GM_channel_name = ""; //채널이름
    public int GM_money = 0; //돈
    public int GM_health = 0; //건강
    public int GM_charm = 0; //매력
    public int GM_edit = 0; //편집
    public int GM_subscriber = 100; //구독자수
    public string GM_youtubaButton = "노버튼"; //현재 유저가 지닌 최고 버튼
    public bool GM_uploadChkLocker = false; //보관함에서 동영상업로드 여부 확인
    public bool GM_uploadChkMain = false; //메인에서 동영상 업로드 후 시간재기 위해 쓸 변수
    public int[] GM_conceptCnt = new int[8]; //컨셉개수

    //GameTime
    public bool GT_tutorialChk = true;
    public bool GT_monthChange;
    public string[] GT_dayEvent = new string[32]; //매달 일에 들어가는 일정
    public List<int> GT_cummunity = new List<int>(); //커뮤니티는 매 달 4개씩 가능하므로 그거 처리

    //Upload_sceneManager-OK
    public List<float> UM_uploadThumnail_r = new List<float>(); //썸네일 배경
    public List<float> UM_uploadThumnail_g = new List<float>(); //썸네일 배경
    public List<float> UM_uploadThumnail_b = new List<float>(); //썸네일 배경
    public List<int> UM_uploadThumnailImage = new List<int>();//썸네일
    public List<string> UM_uploadTitles = new List<string>(); //동영상 제목
    public List<int> UM_uploadHits = new List<int>(); //동영상조회수
    public List<string> UM_uploadConcepts = new List<string>(); //동영상 컨셉
    public List<int> UM_uploadAds = new List<int>(); //동영상 광고개수
    public List<int> UM_uploadPayoffs = new List<int>(); //동영상 총수익

    //DayEventController-OK
    public int DC_prevDay = 0;
    public int DC_prevMonth = 0;

    //VideoUploadTime-OK
    public float VT_afterUploadTime = 0.0f;
    public float VT_afterLiveTime = 0.0f;

    //ItemLocker-OK
    public int[] IL_Index = new int[4];
    public int[,] IL_HealthItems = new int[4,3];
    public int[,] IL_CharmItems = new int[30,3];
    public int[,] IL_EditItems = new int[30,3];
}
