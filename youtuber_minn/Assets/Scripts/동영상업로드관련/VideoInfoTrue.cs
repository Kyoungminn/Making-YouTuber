using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoInfoTrue : MonoBehaviour
{
    public GameObject video;

    public void OnVideoInfo()
    {
        video.SetActive(true);
    }

    private void Awake()
    {
        video = GameObject.Find("VideoInfo");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
