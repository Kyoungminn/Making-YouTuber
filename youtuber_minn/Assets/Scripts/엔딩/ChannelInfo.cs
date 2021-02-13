using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelInfo : MonoBehaviour
{

    public Image endImage;
    public Text endText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEndingClick()
    {
        int idx = gameObject.transform.GetSiblingIndex();
        Debug.Log(idx);
        int endingConceptNum = EndingController.gameEnding[idx];
        string channel_name = EndingController.gameEnding_channel[idx];
        string human_name = EndingController.gameEnding_name[idx];

        endImage.sprite = ChannelController._channelControlelr.endingImage[endingConceptNum];
        string endPublicText = "구독자 100명으로 시작했던 " + channel_name + "은/는 어느새 구독자 5천만 명을 넘겨 루비 버튼을 받게 되었다.";
        switch (endingConceptNum)
        {
            case 0:
                endText.text = endPublicText + "\n토크 방송으로 유명했던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 엄청난 러브콜을 받고 모든 연예인들이 함께 출현하고 싶어하는 국민MC라는 타이틀을 얻게 되었다.";
                break;
            case 1:
                endText.text = endPublicText + "\n게임 방송으로 유명했던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 루비버튼을 받고 프로게이머가 되어 억대 연봉을 받는 제2의 페이커가 되었다.";
                break;
            case 2:
                endText.text = endPublicText + "\n먹방으로 유명했던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 루비버튼을 받고 놀라운 일요일-파솔라마켓에서 햇님으로 활약하게 되었다.";
                break;
            case 3:
                endText.text = endPublicText + "\n요리 방송으로 유명했던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 루비버튼을 받고 세계 최고 호텔의 셰프가 되었다.";
                break;
            case 4:
                endText.text = endPublicText + "\n브이로그 영상으로 유명했던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 루비버튼을 받고 대형 기획사를 이끄는 기획사 사장이 되었다.";
                break;
            case 5:
                endText.text = endPublicText + "\n꾸준히 ASMR 영상을 올려 수면을 유도하던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 루비버튼을 받고 사람을 재우는 수면전문의가 되었다.";
                break;
            case 6:
                endText.text = endPublicText + "\n노래 실력으로 유명했던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 루비버튼을 받고 잠실주경기장에서 콘서트를 하는 가수가 되었다.";
                break;
            case 7:
                endText.text = endPublicText + "\n트렌드란 트렌드는 전부 시도하던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 루비버튼을 받고 유행을 이끄는 인플루언서가 되었다.";
                break;
            default:
                endText.text = endPublicText + "\n다양한 영상을 다루던 " + channel_name +
                    "채널 주인 " + human_name +
                    "은/는 대한민국 최고의 PD가 되었다.";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
