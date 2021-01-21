using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upload_sceneManager : MonoBehaviour
{
    public static Upload_sceneManager inst = null;

    //한 동영상에 저장되는 정보
    public static List<Image> uploadThumnail = new List<Image>(); //썸네일 배경
    public static List<Image> uploadThumnailImage = new List<Image>();//썸네일
    public static List<string> uploadTitles = new List<string>(); //동영상 제목
    public static List<int> uploadHits = new List<int>(); //동영상조회수
    public static List<string> uploadConcepts = new List<string>(); //동영상 컨셉
    public static List<int> uploadAds = new List<int>(); //동영상 광고개수
    public static List<float> uploadPayoffs = new List<float>(); //동영상 총수익
    //


    void Awake()
    {
        inst = this;    
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
