using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCalendar : MonoBehaviour
{
    public Text _yearNumText;
    public Text _monthNumText;

    public GameObject _item;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;

    // Start is called before the first frame update
    void Start()
    {
        TutorialcreateCalendar();
    }

    public void TutorialCalendarSaveClick()
    {
        int idx = int.Parse(_dateItems[21].transform.GetComponentInChildren<Text>().text);
        GameTime.dayEvent[idx] = "합방";
        GameTime.eventDay.Add("합방", idx);
        _dateItems[21].transform.GetChild(1).gameObject.GetComponent<Text>().text = "합방";

        Debug.Log(GameTime.dayEvent[idx][0]);

    }

    void TutorialcreateCalendar()
    {
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
            item.transform.localPosition = new Vector3((i % 7) * 150 + startPos.x, startPos.y - (i / 7) * 140, startPos.z);

            _dateItems.Add(item);
        }

        _dateTime = new DateTime(GameManager.game_year, GameManager.game_month, (int)GameManager.game_day);

        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

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

        _yearNumText.text = _dateTime.Year.ToString();
        _monthNumText.text = _dateTime.Month.ToString("D2");
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
