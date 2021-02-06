using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveBroadcast : MonoBehaviour
{
    public Sprite[] spriteArray; //구독자그래픽

    public Text _comment;
    public Image subscriberImage;
    string live_comment;
    public List<string> liveComments = new List<string>();
    public GameObject live, liveEnd;


    // Start is called before the first frame update
    void Start()
    {
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


        StartCoroutine(Live_ing());
    }

    void Live_end()
    {
        VideoUploadTime.afterLiveTime = 600.0f;
        live.SetActive(false);
        liveEnd.SetActive(true);
    }

    IEnumerator Live_ing()
    {
        for(int i = 0 ; i < 29 ; i++)
        {
            int rand = Random.Range(0, liveComments.Count);
            int rand2 = Random.Range(0, spriteArray.Length);

            int r1 = Random.Range(0, 256);
            int r2 = Random.Range(0, 256);
            int r3 = Random.Range(0, 256);
            
            _comment.text = liveComments[rand];
            subscriberImage.color = new Color(r1 / 255f, r2 / 255f, r3 / 255f);
            //subscriberImage.sprite = spriteArray[rand2];
            yield return new WaitForSeconds(2.0f);
        }

        Live_end();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
