using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTime : MonoBehaviour
{
    public static bool tutorialChk = true;
    public static bool monthChange;

    public static string[] dayEvent = new string[32]; //매달 일에 들어가는 일정
    public static Dictionary<string, int> eventDay = new Dictionary<string, int>(); //매달에 대한 이벤트 존재 여부 및 몇 일에 있는지 저장
    public static List<int> cummunity = new List<int>(); //커뮤니티는 매 달 4개씩 가능하므로 그거 처리

    public static bool[] videoCalendar = new bool[32]; //동영상 업로드 후 일정에 저장
    public static bool[] liveCalendar = new bool[32]; //라이브 후 일정에 저장

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.game_time += (Time.deltaTime / 60.0f);
        GameManager.game_day += (Time.deltaTime / 60.0f);

        int month = GameManager.game_month;
        float day = GameManager.game_day;

        if (GameManager.game_month == 9 && EventController._eventInstance.monthEvent[9].Contains("팬페스트"))
        {
            dayEvent[1] = "팬페스트";
            eventDay.Add("팬페스트", 1);
        }

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if (day >= 32.0f)
            {
                monthChange = true;
                dayEvent = new string[32];
                dayEvent.Initialize();
                eventDay = new Dictionary<string, int>();
                cummunity = new List<int>();
                videoCalendar = new bool[32];
                liveCalendar = new bool[32];
                GameManager.game_day = 1.0f;
                GameManager.game_month++;
                if (GameManager.game_month > 12)
                {
                    GameManager.game_year++;
                    GameManager.game_month = 1;
                }
            }
        }

        else if (month == 2)
        {
            if (day >= 29.0f)
            {
                monthChange = true;
                dayEvent = new string[32];
                dayEvent.Initialize();
                eventDay = new Dictionary<string, int>();
                cummunity = new List<int>();
                videoCalendar = new bool[32];
                liveCalendar = new bool[32];
                GameManager.game_day = 1.0f;
                GameManager.game_month++;
            }
        }

        else
        {
            if (day >= 31.0f)
            {
                monthChange = true;
                dayEvent = new string[32];
                dayEvent.Initialize();
                eventDay = new Dictionary<string, int>();
                cummunity = new List<int>();
                videoCalendar = new bool[32];
                liveCalendar = new bool[32];
                GameManager.game_day = 1.0f;
                GameManager.game_month++;
            }
        }

        //Debug.Log("현재시간: " + (int)GameManager.game_time);
        //Debug.Log(GameManager.game_month + "월" + (int)GameManager.game_day + "일");

        if(VideoInfomation.hitChk)
        {
            StartCoroutine(CountBackHit());
        }
    }   

    IEnumerator CountBackHit()
    {
        LockerVideo.current += (LockerVideo.offset * Time.deltaTime);
        yield return null;
    }
}

