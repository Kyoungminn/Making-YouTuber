﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VideoUpload : MonoBehaviour
{
    public GameObject uploadDonetxt;  
    public Button deleteButton;
    public Button conceptButton;
    public Button uploadButton;
    public Slider uploading;

    public GameObject noConcept; //컨셉 미선택시 뜨는 팝업


    // Start is called before the first frame update
    void Start()
    {
        conceptButton.enabled = true;
        uploading.gameObject.SetActive(false);
        uploadDonetxt.SetActive(false);
    }

    public void UploadClick()
    {
        if (GameObject.Find("GameManager").GetComponent<KeyInput>().conceptText != "")
        {
            deleteButton.enabled = false;
            conceptButton.enabled = false;
            uploadButton.gameObject.SetActive(false);
            uploading.gameObject.SetActive(true);

            StartCoroutine(Loading());
        }

        else
        {
            GameObject.Find("GameManager").GetComponent<KeyInput>().enabled = false;
            noConcept.SetActive(true);
        }
   
    }

    IEnumerator Loading()
    {
        yield return null;
        while(uploading.value <= 1f)
        {
            yield return null;
            if(uploading.value < 1f) //업로드중 5초동안
            {
                uploading.value = Mathf.MoveTowards(uploading.value, 1f, Time.deltaTime * (0.2f));
            }
            else //업로드 완료
            {
                uploading.gameObject.SetActive(false);
                uploadDonetxt.SetActive(true);
                deleteButton.enabled = true;
                
                VideoUploadTime.afterUploadTime = 180.0f;
                GameManager.uploadChkLocker = true;
                GameManager.uploadChkMain = true;

                break;
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
