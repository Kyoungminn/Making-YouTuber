using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileInfo : MonoBehaviour 
{
    public Text name_value1;
    public Text sub_value1;
    public Text money_value1;
    public Text channel_value;

    //프로필 팝업 값
    public Text name_value;
    public Text sub_value;
    public Text money_value;
    public Text edit_value;
    public Text charm_value;
    public Text health_value;

    //일정 값
    public Text day_Text;

    public Image charProfile;
    public Sprite[] profileImages = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        name_value1.text = GameManager.human_name;
        sub_value1.text = GameManager.subscriber.ToString();
        money_value1.text = GameManager.money.ToString();
        channel_value.text = GameManager.channel_name;

        name_value.text = GameManager.human_name;
        sub_value.text = GameManager.subscriber.ToString();
        money_value.text = GameManager.money.ToString();
        edit_value.text = GameManager.edit.ToString();
        charm_value.text = GameManager.charm.ToString();
        health_value.text = GameManager.health.ToString();

        charProfile.sprite = profileImages[SetData.profileIdx-2]; //프로필표시
        Debug.Log(SetData.profileIdx - 2);

    }

    void Update()
    {
        //구독자수, 돈 변화하는 값이므로
        sub_value1.text = GameManager.subscriber.ToString();
        money_value1.text = GameManager.money.ToString();

        sub_value.text = GameManager.subscriber.ToString();
        money_value.text = GameManager.money.ToString();
        edit_value.text = GameManager.edit.ToString();
        charm_value.text = GameManager.charm.ToString();
        health_value.text = GameManager.health.ToString();

        //일정표시
        day_Text.text = GameManager.game_year.ToString() + "/" + GameManager.game_month.ToString("D2") + "/" + ((int)GameManager.game_day).ToString("D2");
    }

}

