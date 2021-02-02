using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonItem : MonoBehaviour
{
    public void OnEventBtClick()
    {
        CalendarController._calendarInstance.OnEventButtonClick(gameObject, gameObject.GetComponentInChildren<Text>().text);
    }
}
