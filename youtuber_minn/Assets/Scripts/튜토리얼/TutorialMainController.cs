using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMainController : MonoBehaviour
{
    public GameObject click_pannel, click_pannel2;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.human_name;
        gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = "( "+GameManager.channel_name+" )";
    }

    public void coinAdd()
    {
        GameTime.tutorialChk = false;
        GameManager.health = 0;
        GameManager.subscriber = 100;
        GameManager.money = 1000;
        GameObject.Find("Panel_Profile").transform.GetChild(6).gameObject.GetComponent<Text>().text = GameManager.money.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        
        if(click_pannel)
        {
            Text _name = click_pannel.transform.GetChild(4).GetComponent<Text>();
            _name.text = GameManager.human_name;
        }

        if(click_pannel2)
        {
            Text _name = click_pannel2.transform.GetChild(4).GetComponent<Text>();
            _name.text = GameManager.human_name;
        }
    
    }
}
