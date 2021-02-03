using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoInfomation : MonoBehaviour
{
    public GameObject video;
    public GameObject hitting;
    public static int indexNumber;
    public static bool videoChk = false;
    public static bool hitChk = true;
    public Image thum, thumnail;
    public Text infoma;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (videoChk && hitChk)
        {
            videoChk = false;
            StartCoroutine(Hit_ing());
        }

        if (videoChk && !hitChk)
        {
            videoChk = false;
            video.SetActive(true);

            int videoNum = Upload_sceneManager.uploadTitles.Count;
            int id = videoNum - 1 - indexNumber;
            string title = Upload_sceneManager.uploadTitles[id];
            int hit = Upload_sceneManager.uploadHits[id];
            string concept = Upload_sceneManager.uploadConcepts[id];
            int ads = Upload_sceneManager.uploadAds[id];
            float payoff = Upload_sceneManager.uploadPayoffs[id];

            thum.sprite = Upload_sceneManager.uploadThumnail[id].sprite;
            thum.color = Upload_sceneManager.uploadThumnail[id].color;
            thumnail.sprite = Upload_sceneManager.uploadThumnailImage[id].sprite;

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
        yield return new WaitForSeconds(2.0f);
        hitting.SetActive(false);
    }
}
