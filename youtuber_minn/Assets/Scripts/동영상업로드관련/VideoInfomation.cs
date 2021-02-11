using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoInfomation : MonoBehaviour
{
    public GameObject video;
    public GameObject hitting;
    public static int indexNumber; //영상의 인덱스번호(최근영상이 0번)
    public static bool videoChk = false; //눌렸는지 확인
    public static bool hitChk = false; //조회수 처리중인 영상존재하는지 확인
    public Image thum;
    public GameObject thumnail;
    public Text infoma;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        int videoNum = Upload_sceneManager.uploadTitles.Count; //영상개수
        int id = videoNum - 1 - indexNumber; //영상의 list번호

        if (videoChk && hitChk && id == (videoNum - 1))
        {
            videoChk = false;
            StartCoroutine(Hit_ing());
        }

        else if (videoChk)
        {
            videoChk = false;
            video.SetActive(true);

            string title = Upload_sceneManager.uploadTitles[id];
            int hit = Upload_sceneManager.uploadHits[id];
            string concept = Upload_sceneManager.uploadConcepts[id];
            int ads = Upload_sceneManager.uploadAds[id];
            int payoff = Upload_sceneManager.uploadPayoffs[id];

            thum.color = new Color(Upload_sceneManager.uploadThumnail_r[id],
                                   Upload_sceneManager.uploadThumnail_g[id],
                                   Upload_sceneManager.uploadThumnail_b[id]);
            for(int i=0;i<24;i++)
            {
                int pr = i / 3;
                int chd = i % 3;
                if(i == Upload_sceneManager.uploadThumnailImage[id])
                {
                    thumnail.transform.GetChild(pr).transform.GetChild(chd).gameObject.SetActive(true);
                }
                else
                {
                    thumnail.transform.GetChild(pr).transform.GetChild(chd).gameObject.SetActive(false);
                }
            }

            infoma.text = "제목: " + title
                     + "\n조회수: " + hit.ToString()
                     + "\n컨셉: " + concept
                     + "\n광고개수: " + ads.ToString()
                     + "\n총수익: " + payoff.ToString();
        }
    }

    IEnumerator Hit_ing()
    {
        hitting.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        hitting.SetActive(false);
    }
}
