using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour {

    public GameObject _dayPopup;

    public void OnDateItemClick()
    {
        CalendarController._calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
        _dayPopup.SetActive(true);
    }
}
