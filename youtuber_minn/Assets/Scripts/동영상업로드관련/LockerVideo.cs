using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerVideo : MonoBehaviour
{
    public Text info;
    public Image thumnail, thumnailImage;

    // Start is called before the first frame update
    void Start()
    {
        int videoNum = Upload_sceneManager.uploadTitles.Count;
        int indexNum = gameObject.transform.GetSiblingIndex();
        int id = videoNum - 1 - indexNum;
        string title = Upload_sceneManager.uploadTitles[id];
        int hit = Upload_sceneManager.uploadHits[id];

        Debug.Log("썸네일: " + Upload_sceneManager.uploadThumnail.Count);
        thumnail.sprite = Upload_sceneManager.uploadThumnail[id].sprite;
        thumnail.color = Upload_sceneManager.uploadThumnail[id].color;
        thumnailImage.sprite = Upload_sceneManager.uploadThumnailImage[id].sprite;

        info.text = "제목: " + title
                 +"\n조회수: " + hit.ToString();

        Debug.Log(Upload_sceneManager.uploadTitles.Count);
        Debug.Log("인덱스: " + indexNum);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
