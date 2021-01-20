using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upload_sceneManager : MonoBehaviour
{
    public static Upload_sceneManager inst = null;

    public static bool uploadChkLocker = false; //보관함에서 동영상업로드 여부 확인
    public static bool uploadChkMain = false; //메인에서 동영상 업로드 후 시간재기 위해 쓸 변수

    //한 동영상에 저장되는 정보
    public static List<Image> uploadThumnail = new List<Image>(); //썸네일 배경
    public static List<Image> uploadThumnailImage = new List<Image>();//썸네일
    public static List<string> uploadTitles = new List<string>(); //동영상 제목
    public static List<int> uploadHits = new List<int>(); //동영상조회수
    public static List<string> uploadConcepts = new List<string>(); //동영상 컨셉
    public static List<int> uploadAds = new List<int>(); //동영상 광고개수
    public static List<float> uploadPayoffs = new List<float>(); //동영상 총수익
    //

    public static Dictionary<string, int> conceptCnt = new Dictionary<string, int>(); //컨셉 종류 카운트

    public int subscribers = 100; //구독자수
    public string youtubeButton; //버튼


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
