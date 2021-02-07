using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EventButtonController : MonoBehaviour
{
    public CalendarController calControll;

    public GameObject _eventButton;
    public List<GameObject> eventButtons = new List<GameObject>();

    public static EventButtonController _eventButtonController;

    private void Awake()
    {
        calControll = GameObject.Find("CalendarController").GetComponent<CalendarController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _eventButtonController = this;

        Vector3 startPos = _eventButton.transform.localPosition;
        eventButtons.Clear();
        eventButtons.Add(_eventButton);

        for (int i = 1; i < 4; i++)
        {
            GameObject events = GameObject.Instantiate(_eventButton) as GameObject;
            events.name = "eventBt" + (i + 1).ToString();
            events.transform.SetParent(_eventButton.transform.parent);
            events.transform.localScale = Vector3.one;
            events.transform.localRotation = Quaternion.identity;
            events.transform.localPosition = new Vector3(startPos.x, startPos.y - (i % 4) * 100, startPos.z);

            eventButtons.Add(events);
        }

        //createEventButton();
    }

    public void createEventButton() //eventBt에 이벤트 글씨 입힐 함수
    {
        for(int i = 0 ; i <= 31 ; i++)
        {
            calControll.dayEventClone[i] = GameTime.dayEvent[i];
        }
        calControll.eventDayClone = new Dictionary<string, int>(GameTime.eventDay);
        calControll.cummunityClone = GameTime.cummunity.ToList();

        int now_month = int.Parse(calControll._monthNumText.text);

        for (int i = 0; i < EventController._eventInstance.monthEvent[now_month].Count; i++)
        {
            eventButtons[i].SetActive(true);
            Text eventButtonText = eventButtons[i].GetComponentInChildren<Text>();
            eventButtonText.text = EventController._eventInstance.monthEvent[now_month][i];

            if (eventButtonText.text == "팬페스트") //팬페스트는 9/1 고정일정
            {
                eventButtons[i].GetComponent<Image>().color = new Color(186f / 255f, 186f / 255f, 186f / 255f);
                eventButtons[i].GetComponent<Button>().enabled = false;
            }

            else if (eventButtonText.text == "커뮤니티 글 작성")
            {
                if(GameTime.cummunity.Contains(int.Parse(calControll.currentDay))) //빨강
                {
                    eventButtons[i].GetComponent<Image>().color = new Color(255f / 255f, 88f / 255f, 88f / 255f);
                    eventButtons[i].GetComponent<Button>().enabled = true;
                }
                else
                {
                    if(GameTime.cummunity.Count == 4) //회색, 사용불가
                    {
                        eventButtons[i].GetComponent<Image>().color = new Color(186f / 255f, 186f / 255f, 186f / 255f);
                        eventButtons[i].GetComponent<Button>().enabled = false;
                    }
                    else //하양, 선택가능
                    {
                        eventButtons[i].GetComponent<Image>().color = new Color(1f, 1f, 1f);
                        eventButtons[i].GetComponent<Button>().enabled = true;
                    }
                }
            }

            else
            {
                if (GameTime.eventDay.ContainsKey(eventButtonText.text))
                {
                    if (GameTime.eventDay[eventButtonText.text] == int.Parse(calControll.currentDay))
                    {
                        //빨강
                        eventButtons[i].GetComponent<Image>().color = new Color(255f / 255f, 88f / 255f, 88f / 255f);
                        eventButtons[i].GetComponent<Button>().enabled = true;
                    }

                    else
                    {
                        //회색
                        eventButtons[i].GetComponent<Image>().color = new Color(186f / 255f, 186f / 255f, 186f / 255f);
                        eventButtons[i].GetComponent<Button>().enabled = false;
                    }
                }

                else //하양
                {
                    eventButtons[i].GetComponent<Image>().color = new Color(1f, 1f, 1f);
                    eventButtons[i].GetComponent<Button>().enabled = true;
                }
            }
            
        }

        for (int i = EventController._eventInstance.monthEvent[now_month].Count; i < 4; i++)
        {
            eventButtons[i].SetActive(false);
        }
    }

}
