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

    public void hitView(int ogHit)
    {
        float hit2 = (float)ogHit * 0.0001f; //만단위 넘어갈 시
        info.text = "제목: " + title  + "\n조회수: " + string.Format("{0:N1}",hit2) + " 만회";
    }

    // Start is called before the first frame update
    void Start()
    {
        VideoInfomation.hitChk = false;

        int videoNum = Upload_sceneManager.uploadTitles.Count;
        int indexNum = gameObject.transform.GetSiblingIndex();
        int id = videoNum - 1 - indexNum;
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

        if ((videoNum - 1) == id && GameManager.uploadChkLocker)
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
                info.text = "제목: " + title + "\n조회수: " + hit.ToString();
            }
        }


        Debug.Log(Upload_sceneManager.uploadTitles.Count);
        Debug.Log("인덱스: " + indexNum);

    }

    IEnumerator CountHit()
    {
        float current = 0.0f; //조회수 초기
        float duration = 60.0f; //카운팅에 걸리는 시간
        float offset = (hit - current) / duration;

        while (current < hit)
        {
            current += offset * Time.deltaTime;
            if (current >= 10000)
            {
                hitView((int)current);
            }
            else
            {
                info.text = "제목: " + title + "\n조회수: " + ((int)current).ToString();
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
            info.text = "제목: " + title + "\n조회수: " + ((int)current).ToString();
        }

        VideoInfomation.hitChk = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
