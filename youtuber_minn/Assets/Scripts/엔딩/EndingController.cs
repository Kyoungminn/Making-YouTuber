using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    public Text channelTxt, endingHit;
    float endinghits = 0;

    // Start is called before the first frame update
    void Start()
    {
        channelTxt.text = GameManager.channel_name;
    }

    // Update is called once per frame
    void Update()
    {
        if(endingHit.gameObject.activeSelf == true)
        {
            endinghits += (Time.deltaTime * 10000.0f);
            if(endinghits > 10000f)
            {
                endingHit.text = string.Format("{0:0.0}", endinghits / 10000f) + "만 회";
            }
            else endingHit.text = ((int)endinghits).ToString() + "회";
        }
    }
}
