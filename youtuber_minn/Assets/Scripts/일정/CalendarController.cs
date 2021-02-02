using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CalendarController : MonoBehaviour
{
    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;

    public Text bottomYear;
    public Text bottomMonth;

    public Text _target;

    public GameObject _item;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;
    public static CalendarController _calendarInstance;

    private int startDayId, lengthDay;
    public string currentDay;

    public bool selectChk;
    public string evt;

    public List<List<string>> dayEventClone = new List<List<string>>();
    public Dictionary<string, int> eventDayClone = new Dictionary<string, int>();

    void Start()
    {
        _calendarInstance = this;
        Vector3 startPos = _item.transform.localPosition;
        _dateItems.Clear();
        _dateItems.Add(_item);

        for (int i = 1; i < _totalDateNum; i++)
        {
            GameObject item = GameObject.Instantiate(_item) as GameObject;
            item.name = "Item" + (i + 1).ToString();
            item.transform.SetParent(_item.transform.parent);
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            item.transform.localPosition = new Vector3((i % 7) * 150  + startPos.x, startPos.y - (i / 7) * 140, startPos.z);

            _dateItems.Add(item);
        }
        
        StartCoroutine(CreateCalendar());
        
    }

    IEnumerator CreateCalendar()
    {
        _dateTime = new DateTime(GameManager.game_year, GameManager.game_month, (int)GameManager.game_day);

        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        startDayId = index;

        int date = 0;
        for (int i = 0; i < _totalDateNum; i++)
        {
            Text label = _dateItems[i].GetComponentInChildren<Text>();
            _dateItems[i].SetActive(false);

            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    _dateItems[i].SetActive(true);

                    label.text = (date + 1).ToString("D2");
                    date++;
                }
            }
        }

        lengthDay = date;

        Debug.Log(startDayId);
        Debug.Log(lengthDay);

        _yearNumText.text = bottomYear.text = _dateTime.Year.ToString();
        _monthNumText.text = bottomMonth.text = _dateTime.Month.ToString("D2");

        yield return null;

        createEventTextAdd();

    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
    }
   
    public void MonthNext()
    {
        Debug.Log("nextMonth");
        GameManager.game_month++;
        GameManager.game_day = 1.0f;
        StartCoroutine(CreateCalendar());
    }

    //Item 클릭했을 경우 Text에 표시.
    public void OnDateItemClick(string day)
    {
        _target.text = _yearNumText.text + "년" + _monthNumText.text + "월" + int.Parse(day).ToString("D2") + "일";
        currentDay = day;
    }

    public void AfterEventSaveClick()
    {
        GameTime.dayEvent = dayEventClone.ToList();
        GameTime.eventDay = new Dictionary<string, int>(eventDayClone);
        createEventTextAdd();
    }

    public void createEventTextAdd()
    {
        for(int i = startDayId; i < startDayId + lengthDay; i++)
        {
            int idx = i - startDayId + 1;
            _dateItems[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
            if (GameTime.dayEvent[idx].Count > 0)
            { 
                for (int j = 0; j < GameTime.dayEvent[idx].Count; j++)
                {
                    _dateItems[i].transform.GetChild(1).gameObject.GetComponent<Text>().text += GameTime.dayEvent[idx][j] + "\n";
                    //Debug.Log(GameTime.dayEvent[idx][j]);
                }
            }
        }
    }

    public void OnEventButtonClick(GameObject evt, string evtText)
    {
        int cutDay = int.Parse(currentDay);
        if(eventDayClone.ContainsKey(evtText))
        {
            evt.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            dayEventClone[cutDay].Remove(evtText);
            eventDayClone.Remove(evtText);
        }
        else
        {
            evt.GetComponent<Image>().color = new Color(255f / 255f, 88f / 255f, 88f / 255f);
            dayEventClone[cutDay].Add(evtText);
            eventDayClone.Add(evtText, cutDay);
        }
    }
    void Update()
    {
        //Debug.Log(GameTime.monthChange);
        if (GameTime.monthChange)
        {
            Debug.Log("일정다시만들기");
            StartCoroutine(CreateCalendar());
        }
    }
}
