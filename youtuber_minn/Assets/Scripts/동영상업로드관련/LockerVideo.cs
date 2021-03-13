using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerVideo : MonoBehaviour
{
    public Text info;
    public Image thumnail;
    public GameObject thumnailImage;
    int videoNum, hit;
    string title;
    int id; //동영상 번호

    public void hitView(int ogHit)
    {
        float hit2 = (float)ogHit * 0.0001f; //만단위 넘어갈 시
        info.text = title  + "\n조회수: " + string.Format("{0:N1}",hit2) + " 만회";
    }

    // Start is called before the first frame update
    void Start()
    {
        videoNum = Upload_sceneManager.uploadTitles.Count;
        int indexNum = gameObject.transform.GetSiblingIndex();
        id = videoNum - 1 - indexNum;
        title = Upload_sceneManager.uploadTitles[id];
        hit = Upload_sceneManager.uploadHits[id];

        thumnail.color = new Color(Upload_sceneManager.uploadThumnail_r[id],
                                   Upload_sceneManager.uploadThumnail_g[id],
                                   Upload_sceneManager.uploadThumnail_b[id]);
        for (int i = 0; i < 24; i++)
        {
            int pr = i / 3;
            int chd = i % 3;
            if (i == Upload_sceneManager.uploadThumnailImage[id])
            {
                thumnailImage.transform.GetChild(pr).transform.GetChild(chd).gameObject.SetActive(true);
            }
            else
            {
                thumnailImage.transform.GetChild(pr).transform.GetChild(chd).gameObject.SetActive(false);
            }
        }

        //Debug.Log(VideoInfomation.hitChk);
        if ((videoNum - 1) == id && GameManager.uploadChkLocker)
        {
            VideoInfomation.hitChk = true;
            GameManager.uploadChkLocker = false;
            HitCounting._hitCounting.BringHitId(hit, id);
        }
        else
        {
            if (hit >= 10000)
            {
                hitView(hit);
            }
            else
            {
                info.text = title + "\n조회수: " + hit.ToString();
            }
        }


        //Debug.Log(Upload_sceneManager.uploadTitles.Count);
        Debug.Log("인덱스: " + indexNum);

    }

   

    // Update is called once per frame
    void Update()
    {
        if((videoNum - 1) == id && VideoInfomation.hitChk)
        {
            float hitcur = HitCounting._hitCounting.current;
            if (hitcur >= 10000)
            {
                hitView((int)hitcur);
            }
            else
            {
                info.text = title + "\n조회수: " + ((int)hitcur).ToString();
            }

        }
    }
}
