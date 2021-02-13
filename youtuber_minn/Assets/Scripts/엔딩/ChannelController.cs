using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelController : MonoBehaviour
{
    public static ChannelController _channelControlelr;
    public GameObject _item;
    public Text Nochannel;

    //토킹0,게임1,먹방2,요리3,브이로그4,ASMR5,노래6,유행7,PD8 
    public Sprite[] endingImage = new Sprite[9];
    int endingCnt = 0;
    int endingConceptNum;

    // Start is called before the first frame update
    void Start()
    {
        //test로 엔딩 넣어보기
        //EndingController.gameEnding.Add(0);
        //EndingController.gameEnding_name.Add("배수아");
        //EndingController.gameEnding_channel.Add("엔딩테스트");
        //

        _channelControlelr = this;
        endingCnt = EndingController.gameEnding.Count;
        if(endingCnt != 0)
        {
            _item.SetActive(true);
            Vector3 startPos = _item.transform.localPosition;

            endingConceptNum = EndingController.gameEnding[0];
            _item.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = endingImage[endingConceptNum];
            _item.transform.GetComponentInChildren<Text>().text = EndingController.gameEnding_name[0] + " (" + EndingController.gameEnding_channel[0] + ")";

            for (int i = 1; i < endingCnt; i++)
            {
                GameObject item = GameObject.Instantiate(_item) as GameObject;
                item.SetActive(true);
                item.name = "Ending" + (i + 1).ToString();
                item.transform.SetParent(_item.transform.parent);
                item.transform.localScale = Vector3.one;
                item.transform.localRotation = Quaternion.identity;
                item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y, 0f);

                endingConceptNum = EndingController.gameEnding[i];
                item.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = endingImage[endingConceptNum];
                item.transform.GetComponentInChildren<Text>().text = EndingController.gameEnding_name[i] + " (" + EndingController.gameEnding_channel[i] + ")";
            }
        }

        else
        {
            Nochannel.gameObject.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
