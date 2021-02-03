using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour {

    public GameObject _dayPopup;

    public void OnDateItemClick()
    {
        string calDay = gameObject.GetComponentInChildren<Text>().text;

        if ((int)GameManager.game_day < int.Parse(calDay))
        {
            CalendarController._calendarInstance.OnDateItemClick(calDay);
            _dayPopup.SetActive(true);
            EventButtonController._eventButtonController.createEventButton();
        }
        
    }
}
