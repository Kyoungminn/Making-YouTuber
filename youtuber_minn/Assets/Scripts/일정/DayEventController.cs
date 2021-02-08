using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayEventController : MonoBehaviour
{
    public GameObject eventPopup;
    public Text popupText, statText;
    public Image icon1, icon2;

    public static int prevDay = 0;
    public static int prevMonth = 0;
    bool dayChk = false;

    string _event;
    public Sprite[] icons = new Sprite[3]; //0:구독자, 1:매력, 2:편집

    // Update is called once per frame
    void Update()
    {
        int currentMonth = GameManager.game_month;
        int currentDay = (int)(GameManager.game_day);

        if(prevMonth != currentMonth)
        {
            prevMonth = currentMonth;
            prevDay = 0;
        }
        //Debug.Log("preDay" + prevDay + "cutDay" + currentDay);
        if (GameTime.dayEvent[currentDay] != null && GameTime.dayEvent[currentDay] != "" && currentDay - prevDay > 0)
        {
            Debug.Log("preDay" + prevDay + "cutDay" + currentDay);
            prevDay = currentDay;
            dayChk = true;
        }
        if (dayChk) //하루 일정 이벤트 실행
        {
            dayChk = false;
            eventPopup.SetActive(true);

            SoundManager._soundInstance.PopupAudio();

            _event = GameTime.dayEvent[currentDay];

            if(_event == "합방")
            {
                popupText.text = "오늘은 OO 유투바와 합방을 진행하는 날입니다. 평소보다 보는 사람이 많네요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[2];
                statText.text = " + 1 % \n";
            }
            else if(_event == "팬미팅")
            {
                popupText.text = "오늘은 팬들과의 팬미팅이 있는 날입니다. 즐거운 하루 되세요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[1];
                statText.text = " + 5 % \n";
            }
            else if (_event == "팬페스트")
            {
                popupText.text = "유투바에서 진행하는 펜페스트에 참가합니다. 사람이 정말 많군요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[0];
                statText.text = " + 3 % \n";
            }
            else if (_event == "방송출연")
            {
                popupText.text = "유명 유튜바로 \'쉬면 뭐하니\'에 출연했습니다. 새로운 구독자가 꽤 생긴 것 같군요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[0];
                statText.text = " + 5 % \n";
            }
            else if (_event == "행사게스트")
            {
                popupText.text = "탁원한 입담으로 유명 행사에 게스트로 참석하게 되었습니다. 실수하지 않게 조심해야겠어요.";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(true);
                icon1.sprite = icons[0];
                icon2.sprite = icons[2];
                statText.text = " + 1 % \n + 1 % ";
            }
            else if (_event == "인터뷰")
            {
                popupText.text = "\'분명특급\'에 게스트로 출연하여 인터뷰를 하였습니다. 진행자와 성격이 잘 맞네요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[1];
                statText.text = " + 5 % \n";
            }
            else if (_event == "유투바 대회")
            {
                popupText.text = "다양한 유투바들이 참석하는 대회에 참가하게 되었습니다. 인지도도 얻고 타유투바들과도 친목을 다져보세요.";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(true);
                icon1.sprite = icons[0];
                icon2.sprite = icons[2];
                statText.text = " + 1 % \n + 1 %";
            }
            else if (_event == "팬싸인회")
            {
                popupText.text = "팬싸인회에 많은 팬들이 기다리고 있습니다! 이렇게 보니까 인기가 실감나네요.";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[1];
                statText.text = " + 5 % \n";
            }
            else if (_event == "강연")
            {
                popupText.text = "\'유튜바 되기\'에 대한 강연 초청이 들어왔습니다. 벌써 많이 성장한 것 같네요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[2];
                statText.text = " + 3 % \n";
            }
            else if (_event == "라디오 출연")
            {
                popupText.text = "오늘은 유튜바 특집으로 심야 라디오에 출연했더니 좋은 목소리로 유명세를 타게 되었습니다.";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[1];
                statText.text = " + 5 % \n";
            }
            else if (_event == "팟캐스트 게스트 출연")
            {
                popupText.text = "오늘은 OO채널 팟캐스트 방송에 출연하는 날입니다. 구독자가 많이 생기면 좋겠네요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[0];
                statText.text = " + 1 % \n";
            }
            else //커뮤니티 글 작성
            {
                popupText.text = "팬들을 위해 커뮤니티에 글을 작성해주세요!";
                icon1.gameObject.SetActive(true); icon2.gameObject.SetActive(false);
                icon1.sprite = icons[0];
                statText.text = " + 1 % \n";
            }
        }
    }

    public void OnEventPopupClick()
    {
        int _edit = GameManager.edit; //편집
        int _charm = GameManager.charm; //매력
        int _subscriber = GameManager.subscriber; //구독자

        Debug.Log("이전구독자수: " + _subscriber + "\n편집: " + _edit + "\n매력: " + _charm);

        GameManager.health -= 5;

        if (_event == "합방")
        {
            //편집 + 1%
            GameManager.edit += (_edit / 100);
        }
        else if (_event == "팬미팅")
        {
            //매력 + 5 %
            GameManager.charm += (int)((float)_charm * 0.05f);
        }
        else if (_event == "팬페스트")
        {
            //구독자 + 3 %
            GameManager.subscriber += (int)((float)_subscriber * 0.03f);
        }
        else if (_event == "방송출연")
        {
            //구독자 + 5 % 
            GameManager.subscriber += (int)((float)_subscriber * 0.05f);
        }
        else if (_event == "행사게스트")
        {
            //구독자 + 1 % 편집 + 1 %
            GameManager.subscriber += (_subscriber / 100);
            GameManager.edit += (_edit / 100);
        }
        else if (_event == "인터뷰")
        {
            //매력 + 5 % "
            GameManager.charm += (int)((float)_charm * 0.05f);
        }
        else if (_event == "유투바 대회")
        {
            //구독자 + 1 % 편집 + 1 % "
            GameManager.subscriber += (_subscriber / 100);
            GameManager.edit += (_edit / 100);
        }
        else if (_event == "팬싸인회")
        {
            //매력 + 5 % "
            GameManager.charm += (int)((float)_charm * 0.05f);
        }
        else if (_event == "강연")
        {
            //편집 + 3 % "
            GameManager.edit += (int)((float)_edit * 0.03f);
        }
        else if (_event == "라디오 출연")
        {
            //매력 + 5 % ";
            GameManager.charm += (int)((float)_charm * 0.05f);
        }
        else if (_event == "팟캐스트 게스트 출연")
        {
            //구독자 + 1 % "
            GameManager.subscriber += (_subscriber / 100);
        }
        else //커뮤니티 글 작성
        {
            //구독자 + 1 % "
            GameManager.subscriber += (_subscriber / 100);
            
        }

        Debug.Log("구독자수: " + GameManager.subscriber + "\n편집: " + GameManager.edit + "\n매력: " + GameManager.charm);
    }
}
