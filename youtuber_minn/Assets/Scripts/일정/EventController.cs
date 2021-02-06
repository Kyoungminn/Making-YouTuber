using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public CalendarController calControll;

    public List<List<string>> monthEvent = new List<List<string>>();

    public GameObject _events;
    public List<GameObject> eventsObject = new List<GameObject>();

    public static EventController _eventInstance;

    private void Awake()
    {
        calControll = GameObject.Find("CalendarController").GetComponent<CalendarController>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        _eventInstance = this;
        for (int i = 0; i <= 12; i++)
        {
            monthEvent.Add(new List<string>());
        }
        for (int i = 1; i <= 12; i++)
        { 
            monthEvent[i].Add("합방");
            monthEvent[i].Add("커뮤니티 글 작성");
        }
        //monthEvent[1].Add("팬싸인회");
        //monthEvent[2].Add("팬미팅");
        //monthEvent[3].Add("인터뷰");
        //monthEvent[4].Add("강연");
        //monthEvent[5].Add("방송출연");
        monthEvent[6].Add("유투바 대회");  
        //monthEvent[7].Add("라디오 출연");
        //monthEvent[8].Add("팬미팅");
        //monthEvent[9].Add("팬페스트"); 
        monthEvent[9].Add("팟캐스트 게스트 출연");
        //monthEvent[10].Add("강연"); 
        //monthEvent[11].Add("행사게스트");
        monthEvent[12].Add("유투바 대회");

        Vector3 startPos = _events.transform.localPosition;
        eventsObject.Clear();
        eventsObject.Add(_events);

        for (int i = 1; i < 4; i++)
        {
            GameObject events = GameObject.Instantiate(_events) as GameObject;
            events.name = "events" + (i + 1).ToString();
            events.transform.SetParent(_events.transform.parent);
            events.transform.localScale = Vector3.one;
            events.transform.localRotation = Quaternion.identity;
            events.transform.localPosition = new Vector3(startPos.x, startPos.y - (i % 4) * 70, startPos.z);

            eventsObject.Add(events);
        }

        //StartCoroutine(createEvent());
    }

    public IEnumerator createEvent()
    {
        yield return null;

        int now_month = int.Parse(calControll.bottomMonth.text);
        Debug.Log(now_month);

        for(int i = 0 ; i < monthEvent[now_month].Count ; i++)
        {
            eventsObject[i].SetActive(true);
            Text eventText = eventsObject[i].GetComponent<Text>();
            eventText.text = "- " + monthEvent[now_month][i];
        }

        for(int i = monthEvent[now_month].Count; i < 4; i++)
        {
            eventsObject[i].SetActive(false);
        }
        
        CalendarController._calendarInstance.createEventTextAdd();
        
        yield return null;
    }

    public void nextMonth()
    {
        StartCoroutine(createEvent());
    }

    // Update is called once per frame
    void Update()
    {
        int now_month = int.Parse(calControll.bottomMonth.text);

        if (GameManager.subscriber >= 10000)
        {
            if (!monthEvent[4].Contains("강연"))
            {
                monthEvent[4].Add("강연");
                if (now_month == 4) StartCoroutine(createEvent());
            }
            if (!monthEvent[9].Contains("팬페스트"))
            {
                monthEvent[9].Add("팬페스트");
                if (now_month == 9) StartCoroutine(createEvent());
            }
            if (!monthEvent[10].Contains("강연"))
            {
                monthEvent[10].Add("강연");
                if (now_month == 10) StartCoroutine(createEvent());
            }
        }

        if (GameManager.subscriber >= 100000)
        {
            if (!monthEvent[11].Contains("행사게스트"))
            {
                monthEvent[11].Add("행사게스트");
                if (now_month == 11) StartCoroutine(createEvent());
            }
        }
        if (GameManager.subscriber >= 300000)
        {
            if (!monthEvent[1].Contains("팬싸인회"))
            {
                monthEvent[1].Add("팬싸인회");
                if (now_month == 1) StartCoroutine(createEvent());
            }
        }
        if (GameManager.subscriber >= 500000)
        {
            if (!monthEvent[2].Contains("팬미팅"))
            {
                monthEvent[2].Add("팬미팅");
                if (now_month == 2) StartCoroutine(createEvent());
            }
            if(!monthEvent[7].Contains("라디오 출연"))
            {
                monthEvent[7].Add("라디오 출연");
                if (now_month == 7) StartCoroutine(createEvent());
            }
            if (!monthEvent[8].Contains("팬미팅"))
            {
                monthEvent[8].Add("팬미팅");
                if (now_month == 8) StartCoroutine(createEvent());
            }
        }
        if (GameManager.subscriber >= 1000000)
        {
            if (!monthEvent[3].Contains("인터뷰"))
            {
                monthEvent[3].Add("인터뷰");
                if (now_month == 3) StartCoroutine(createEvent());
            }
            if (!monthEvent[5].Contains("방송출연"))
            {
                monthEvent[5].Add("방송출연");
                if (now_month == 5) StartCoroutine(createEvent());
            }
        }
    }
}
