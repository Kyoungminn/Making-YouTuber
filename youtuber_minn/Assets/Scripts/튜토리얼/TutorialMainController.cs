using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.human_name;
        gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = "( "+GameManager.channel_name+" )";
    }

    public void coinAdd()
    {
        GameTime.tutorialChk = false;
        GameManager.health = 51;
        GameManager.subscriber = 100;
        GameManager.money = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetChild(6).gameObject.GetComponent<Text>().text = GameManager.money.ToString();
    }
}
