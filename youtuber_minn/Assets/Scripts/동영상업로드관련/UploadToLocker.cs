using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UploadToLocker : MonoBehaviour
{
    public GameObject videoPrefab;
    public GameObject scrollVideo;
    int videoNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        videoNum = Upload_sceneManager.uploadTitles.Count;
        for(int i=0;i<videoNum;i++)
        {
            Upload_sceneManager.uploadChkLocker = false;
            GameObject child = Instantiate(videoPrefab) as GameObject;
            child.transform.SetParent(scrollVideo.transform);
            child.transform.SetAsFirstSibling();
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, 0.0f);
            child.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Upload_sceneManager.uploadChkLocker)
        {
            
        }
    }
}
