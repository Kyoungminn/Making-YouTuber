using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerVideo : MonoBehaviour
{
    public Text info;
    public Image thumnail, thumnailImage;
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
        int videoNum = Upload_sceneManager.uploadTitles.Count;
        int indexNum = gameObject.transform.GetSiblingIndex();
        int id = videoNum - 1 - indexNum;
        title = Upload_sceneManager.uploadTitles[id];
        hit = Upload_sceneManager.uploadHits[id];

        Debug.Log("썸네일: " + Upload_sceneManager.uploadThumnail.Count);
        thumnail.sprite = Upload_sceneManager.uploadThumnail[id].sprite;
        thumnail.color = Upload_sceneManager.uploadThumnail[id].color;
        thumnailImage.sprite = Upload_sceneManager.uploadThumnailImage[id].sprite;

        if ((videoNum - 1) == id && GameManager.uploadChkLocker)
        {
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
