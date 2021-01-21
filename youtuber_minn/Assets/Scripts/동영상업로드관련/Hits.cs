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
        hits = (int)((float)Upload_sceneManager.inst.subscribers * hits_P);

        Upload_sceneManager.uploadChkLocker = true;
        Upload_sceneManager.uploadChkMain = true;
       

        //업로드 완료 시 동영상들 정보 List에 저장
        string concept = keyinput.conceptText;
        float pay = keyinput.adsCnt * hits * 0.3f;

        Upload_sceneManager.uploadThumnail.Add(thumnail);
        Upload_sceneManager.uploadThumnailImage.Add(thumnailImage);
        Upload_sceneManager.uploadTitles.Add(keyinput.titleText);
        Upload_sceneManager.uploadHits.Add(hits);
        Upload_sceneManager.uploadConcepts.Add(concept);
        Upload_sceneManager.uploadAds.Add(keyinput.adsCnt);
        Upload_sceneManager.uploadPayoffs.Add(pay);
        //


        //업로드 완료 시 컨셉개수카운트
        if (!Upload_sceneManager.conceptCnt.ContainsKey(concept))
        {
            Upload_sceneManager.conceptCnt[concept] = 1;
        }
        else
        {
            Upload_sceneManager.conceptCnt[concept] += 1;
        }

        Debug.Log("조회수: " + hits);
        Debug.Log(concept + ": " + Upload_sceneManager.conceptCnt[concept]);
        Debug.Log(Upload_sceneManager.conceptCnt.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
