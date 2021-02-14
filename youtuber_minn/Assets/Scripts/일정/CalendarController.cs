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

    public string[] dayEventClone = new string[32]; //���� ������ ������ �����ؼ� ������ dayEvent����
    public Dictionary<string, int> eventDayClone = new Dictionary<string, int>(); //���� ������ ������ �����ؼ� ������ eventDay ����
    public List<int> cummunityClone = new List<int>(); //���� ������ ������ �����ؼ� ������ cummunity ����

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

        StartCoroutine(EventController._eventInstance.createEvent());

        yield return null;

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

    //Item Ŭ������ ��� Text�� ǥ��.
    public void OnDateItemClick(string day)
    {
        _target.text = _yearNumText.text + "��" + _monthNumText.text + "��" + int.Parse(day).ToString("D2") + "��";
        currentDay = day;
    }

    public void AfterEventSaveClick()
    {
        for(int i=0;i<=31;i++)
        {
            GameTime.dayEvent[i] = dayEventClone[i];
        }
        GameTime.eventDay = new Dictionary<string, int>(eventDayClone);
        GameTime.cummunity = cummunityClone.ToList();
        createEventTextAdd();
    }

    public void createEventTextAdd() //�޷¿� ���� ǥ��
    {
        for(int i = startDayId; i < startDayId + lengthDay; i++)
        {
            int idx = i - startDayId + 1;
            _dateItems[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
            if (GameTime.dayEvent[idx] != null)
            { 
                _dateItems[i].transform.GetChild(1).gameObject.GetComponent<Text>().text += GameTime.dayEvent[idx] + "\n";
                Debug.Log(idx + " : " + GameTime.dayEvent[idx]);
            }

            if(GameTime.videoCalendar[idx])
            {
                _dateItems[i].transform.GetChild(2).gameObject.SetActive(true);
            }

            if(GameTime.liveCalendar[idx])
            {
                _dateItems[i].transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }

    public void OnEventButtonClick(GameObject evt, string evtText)
    {
        int cutDay = int.Parse(currentDay);

        if (evtText == "Ŀ�´�Ƽ �� �ۼ�")
        {
            if (cummunityClone.Contains(cutDay)) //����->�Ͼ�
            {
                evt.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                dayEventClone[cutDay] = null;
                cummunityClone.Remove(cutDay);
            }
            else //�Ͼ� -> ����
            {
                if(dayEventClone[cutDay] == null || dayEventClone[cutDay] == "")
                {
                    evt.GetComponent<Image>().color = new Color(255f / 255f, 88f / 255f, 88f / 255f);
                    dayEventClone[cutDay] = evtText;
                    cummunityClone.Add(cutDay);
                }
                
            }
        }

        else
        {
            if(eventDayClone.ContainsKey(evtText)) //���� -> �Ͼ�
            {
                evt.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                dayEventClone[cutDay] = null;
                eventDayClone.Remove(evtText);
            }
            else //�Ͼ� -> ����
            {
                if(dayEventClone[cutDay] == null || dayEventClone[cutDay] == "")
                {
                    evt.GetComponent<Image>().color = new Color(255f / 255f, 88f / 255f, 88f / 255f);
                    dayEventClone[cutDay] = evtText;
                    eventDayClone.Add(evtText, cutDay);
                }
                
            }
        }
        
    }

    void Update()
    {
        //Debug.Log(GameTime.monthChange);
        if (GameTime.monthChange)
        {
            Debug.Log("�����ٽø����");
            StartCoroutine(CreateCalendar());

            GameTime.monthChange = false;
        }

        int id = startDayId + (int)GameManager.game_day - 1;
        for(int i = 0 ; i < _totalDateNum ; i++)
        {
            if (i == id) _dateItems[i].GetComponent<Image>().color = new Color(255f / 255f, 117f / 255f, 128f / 255f, 255f / 255f);
            else _dateItems[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
       
    }
}
