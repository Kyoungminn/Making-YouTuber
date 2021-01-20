using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoInfomation : MonoBehaviour
{ 
    public Image thum, thumnail;
    public Text infoma;
   
    // Start is called before the first frame update
    void Start()
    {
        int videoNum = Upload_sceneManager.uploadTitles.Count;
        int indexNum = gameObject.transform.GetSiblingIndex();
        int id = videoNum - 1 - indexNum;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
