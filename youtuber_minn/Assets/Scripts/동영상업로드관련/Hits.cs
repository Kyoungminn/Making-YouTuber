using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hits : MonoBehaviour
{
    public Image thumnail, thumnailImage;
    KeyInput keyinput;
    private int hits;
    private float hits_P;

    private void Awake()
    {
        keyinput = GameObject.Find("GameManager").GetComponent<KeyInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //string youtubaButton = GameManager.youtubaButton;

        int adsProper = keyinput.adsMaxCnt / 2;

        int rand = Random.Range(0, 100);
        if (rand <= 80)
        {
            hits_P = Random.Range(0.1f, 1.0f);
        }
        else
        {
            hits_P = Random.Range(1.0f, 5.0f);
        }
        Debug.Log(hits_P);
        hits = (int)((float)GameManager.subscriber * hits_P);
       
        //적정광고개수 넘을 시 조회수 처리
        if (keyinput.adsCnt > adsProper)
        {
            float rd = Random.Range(0.1f, 1.0f);
            hits = (int)((float)hits * rd);
        }

        //업로드 완료 시 동영상들 정보 List에 저장
        string concept = keyinput.conceptText;
        float pay = (float)keyinput.adsCnt * (float)hits * 0.3f;

        Upload_sceneManager.uploadThumnail_r.Add(thumnail.color.r);
        Upload_sceneManager.uploadThumnail_g.Add(thumnail.color.g);
        Upload_sceneManager.uploadThumnail_b.Add(thumnail.color.b);
        int idx = keyinput.id * 3 + keyinput.rand;
        Debug.Log(idx);
        Upload_sceneManager.uploadThumnailImage.Add(idx);
        Upload_sceneManager.uploadTitles.Add(keyinput.titleText);
        Upload_sceneManager.uploadHits.Add(hits);
        Upload_sceneManager.uploadConcepts.Add(concept);
        Upload_sceneManager.uploadAds.Add(keyinput.adsCnt);
        Upload_sceneManager.uploadPayoffs.Add((int)pay);
        //

        //광고수익 게임머니에 저장
        GameManager.money += (int)pay;

        //업로드 완료 시 컨셉개수카운트
        int conceptIdx = GameManager.EndingConcept[concept];
        GameManager.conceptCnt[conceptIdx]++;

        Debug.Log("조회수: " + hits);
        Debug.Log(concept + ": " + GameManager.conceptCnt[conceptIdx]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
