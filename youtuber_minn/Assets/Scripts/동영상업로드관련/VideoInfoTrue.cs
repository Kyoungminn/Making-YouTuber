using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoInfoTrue : MonoBehaviour
{
    public void OnClickVideoInfo()
    {
        SoundManager._soundInstance.PopupAudio();
        VideoInfomation.indexNumber = gameObject.transform.GetSiblingIndex();
        VideoInfomation.videoChk = true;
    }

    private void Awake()
    {
        
    }

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
