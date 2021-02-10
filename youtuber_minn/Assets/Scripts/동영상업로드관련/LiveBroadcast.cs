using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveBroadcast : MonoBehaviour
{
    TextFade textFade;
    public Sprite[] spriteArray; //구독자그래픽
    public GameObject hairPar, hairPar2, commentBox;

    public Text huwonText;
    public Text _comment;
    public Image subscriberImage;
    string live_comment;
    public List<string> liveComments = new List<string>();
    public GameObject live, liveEnd;

    public bool firstLive = true;

    // Start is called before the first frame update
    void Start()
    {
        textFade = huwonText.GetComponent<TextFade>();

        live_comment = "요즘 굴이 제철이래... " + GameManager.human_name + "얼굴…☆";
        liveComments.Add(live_comment);

        live_comment = GameManager.human_name + " 그닥.. 내 마음속으로 다그닥";
        liveComments.Add(live_comment);

        live_comment = "넌 베를린이야 내게 치명적인 독일 수도";
        liveComments.Add(live_comment);

        live_comment = GameManager.human_name + "은(는) 사슴이야, 내마음을 녹용";
        liveComments.Add(live_comment);

        live_comment = "아 허전하네… 명불허전..";
        liveComments.Add(live_comment);

        live_comment = "같이 루브르 박물관 털다가 너가 조각상인척해서 나만 잡혀갔잖아… ";
        liveComments.Add(live_comment);

        live_comment = GameManager.human_name + " 보고 벽 뿌시다가 우리집 원룸됐어";
        liveComments.Add(live_comment);

        live_comment = GameManager.human_name + " MBTI 검사하면 Cute 나온다며";
        liveComments.Add(live_comment);

        live_comment = "왜 자꾸 같은 티만 입어요? 프리티";
        liveComments.Add(live_comment);

        live_comment = "앞에 벽이 있어. \'완벽\'";
        liveComments.Add(live_comment);

        live_comment = "혼혈 아니야? 천국이랑 한국.";
        liveComments.Add(live_comment);

        live_comment = "나 몰랐는데 " + GameManager.human_name + "좋아하네.";
        liveComments.Add(live_comment);

        live_comment = "여기서 " + GameManager.human_name + "싫어하는 사람 있나? 탕 또 있나?";
        liveComments.Add(live_comment);

        live_comment = GameManager.human_name + "야,,넌 돌잡이 때 내 심장을 잡았어,,,";
        liveComments.Add(live_comment);
        CharacHair();

        StartCoroutine(Live_ing());
    }

    void CharacHair()
    {
        GameObject hairChild, hairChild2;
        for(int i=0;i<hairPar.transform.childCount;i++)
        {
            hairChild = hairPar.transform.GetChild(i).gameObject;
            hairChild2 = hairPar2.transform.GetChild(i).gameObject;
            if(ItemLocker.Index[0] == i)
            {
                hairChild.SetActive(true);
                hairChild2.SetActive(true);
            }
            else
            {
                hairChild.SetActive(false);
                hairChild2.SetActive(false);
            }
        }
    }

    void Live_end()
    {
        VideoUploadTime.afterLiveTime = 600.0f;
        GameManager.health -= 30;

        //라이브방송 수익 계산
        int live_viewer;//라이브방송 시청자수
        if (firstLive) //첫 라이브면 무조건 구독자의 50%시청자
        {
            firstLive = false;
            live_viewer = (int)((float)GameManager.subscriber * 0.5f);
        }
        else
        {
            float rand = Random.Range(1.0f, 5.0f);
            live_viewer = (int)((float)GameManager.subscriber * rand);
        }
        float pay = (float)live_viewer * 0.03f * 1000f * 0.7f; //라이브방송 수익
        GameManager.money += (int)pay;
        //

        //라이브 완료 시 일정에 표시
        GameTime.liveCalendar[(int)GameManager.game_day] = true; 

        live.SetActive(false);
        liveEnd.SetActive(true);
    }

    IEnumerator Live_ing()
    {
        for(int i = 0 ; i < 20 ; i++)
        {
            Debug.Log(GameManager.game_time);

            int rand = Random.Range(0, liveComments.Count);
            int rand2 = Random.Range(0, spriteArray.Length);

            _comment.text = liveComments[rand];
            subscriberImage.sprite = spriteArray[rand2];
            
            commentBox.GetComponent<Animator>().Play("CommentText", -1, 0f);
            yield return new WaitForSeconds(2.0f);
            commentBox.SetActive(false);
            //후원텍스트 랜덤
            huwonText.gameObject.SetActive(false);

            int rand3 = Random.Range(0, 4); 
            Debug.Log(rand3);

            if (rand3 == 0)
            {
                SoundManager._soundInstance.PopupAudio();
                huwonText.gameObject.SetActive(true);
                StartCoroutine(textFade.FadeTextToFullAlpha());
            }
            //
            yield return new WaitForSeconds(1.0f);
            commentBox.SetActive(true);
        }
        Live_end();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
