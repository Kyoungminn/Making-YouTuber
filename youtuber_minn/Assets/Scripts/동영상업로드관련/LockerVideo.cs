using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerVideo : MonoBehaviour
{
    public Text info;
    public Image thumnail;
    public GameObject thumnailImage;
    int hit;
    string title;
    int id; //동영상 번호

    public static float current = 0.0f;
    public static float offset = 0.0f;

    public void hitView(int ogHit)
    {
        float hit2 = (float)ogHit * 0.0001f; //만단위 넘어갈 시
        info.text = title  + "\n조회수: " + string.Format("{0:N1}",hit2) + " 만회";
    }

    // Start is called before the first frame update
    void Start()
    {
        int videoNum = Upload_sceneManager.uploadTitles.Count;
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
        if ((videoNum - 1) == id && (GameManager.uploadChkLocker || VideoInfomation.hitChk))
        {
            VideoInfomation.hitChk = true;
            GameManager.uploadChkLocker = false;
            StartCoroutine(CountHit());
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

    IEnumerator CountHit()
    {
        float duration = 60.0f; //카운팅에 걸리는 시간
        offset = hit / duration;

        while (current < hit)
        {
            current += offset * Time.deltaTime;
            if (current >= 10000)
            {
                hitView((int)current);
            }
            else
            {
                info.text = title + "\n조회수: " + ((int)current).ToString();
            }
            yield return null;
        }

        current = hit;
        if (current >= 10000)
        {
            hitView((int)current);
        }
        else
        {
            info.text = title + "\n조회수: " + ((int)current).ToString();
        }

        VideoInfomation.hitChk = false;
        current = 0.0f;

        //동영상 수익 게임머니에 저장
        GameManager.money += Upload_sceneManager.uploadPayoffs[id];

        Debug.Log("조회수처리정보:" + VideoInfomation.hitChk);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
