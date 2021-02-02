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

    public void createEventButton()
    {
        for(int i = 0 ; i <= 31 ; i++)
        {
            calControll.dayEventClone.Add(new List<string>());
            calControll.dayEventClone[i] = GameTime.dayEvent[i].ToList();
        }
        calControll.eventDayClone = new Dictionary<string, int>(GameTime.eventDay);

        int now_month = int.Parse(calControll._monthNumText.text);

        for (int i = 0; i < EventController._eventInstance.monthEvent[now_month].Count; i++)
        {
            eventButtons[i].SetActive(true);
            Text eventButtonText = eventButtons[i].GetComponentInChildren<Text>();
            eventButtonText.text = EventController._eventInstance.monthEvent[now_month][i];

            if (GameTime.eventDay.ContainsKey(eventButtonText.text))
            {
                if (GameTime.eventDay[eventButtonText.text] == int.Parse(calControll.currentDay))
                {
                    eventButtons[i].GetComponent<Image>().color = new Color(255f / 255f, 88f / 255f, 88f / 255f);
                    eventButtons[i].GetComponent<Button>().enabled = true;
                }

                else
                {
                    eventButtons[i].GetComponent<Image>().color = new Color(186f / 255f, 186f / 255f, 186f / 255f);
                    eventButtons[i].GetComponent<Button>().enabled = false;
                }
            }

            else
            {
                eventButtons[i].GetComponent<Image>().color = new Color(1f, 1f, 1f);
                eventButtons[i].GetComponent<Button>().enabled = true;
            }
        }

        for (int i = EventController._eventInstance.monthEvent[now_month].Count; i < 4; i++)
        {
            eventButtons[i].SetActive(false);
        }
    }

}
