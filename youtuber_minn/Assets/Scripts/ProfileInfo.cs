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

    }

}
