using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoUploadTime : MonoBehaviour
{
    public static float afterUploadTime = 0.0f;
    public static float afterLiveTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (afterUploadTime > 0.0f)
        {
            afterUploadTime -= Time.deltaTime;
            Debug.Log("동영상 후 시간: " + afterUploadTime);
        }

        else afterUploadTime = 0.0f;

        if (afterLiveTime > 0.0f)
        {
            afterLiveTime -= Time.deltaTime;
            Debug.Log("라이브 후 시간: " + afterLiveTime);
        }

        else afterLiveTime = 0.0f;
    }
}
