using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyInput : MonoBehaviour
{
    public bool tutorialKeyboardChk = true;
    public GameObject uploadtxt;
    Hits hits;

    string youtubaButton; //현재 유튜브 버튼

    private int chk = 1; //키보드 구분
    public bool chk2 = true; //썸네일 이미지 관련

    //GUI 해상도 따른 위치조정 변수들
    private float ScreenWidth = 1080.0f;
    private float ScreenHeight = 1920.0f;
    private Vector3 scale = Vector2.zero;
    private Vector3 createPoint;
    private Matrix4x4 svMat = Matrix4x4.identity;


    //제목 컨셉 광고
    public string conceptText = "";
    public string titleText = "";
    public string adsText = "";
    
    public Text conceptTextButton; //컨셉 _____________ text
    public Text adsNumMax; //(최대 개)
    private TouchScreenKeyboard keyboard_t; //제목 키보드
    private TouchScreenKeyboard keyboard_a; //광고 숫자 키보드
    private TouchScreenKeyboardType type; //키보드 타입
    public GUISkin GUISkin; //GUI 종류

    public int adsCnt; //광고개수
    public int adsMaxCnt; //광고최대개수
    public bool adsChk = true; //광고 초과 여부 확인

    //컨셉 맞는 썸네일
    public List<GameObject> thumnailImage = new List<GameObject>();
    public List<GameObject> thumTalking = new List<GameObject>();
    public List<GameObject> thumGame = new List<GameObject>();
    public List<GameObject> thumEating = new List<GameObject>();
    public List<GameObject> thumCook = new List<GameObject>();
    public List<GameObject> thumVlog = new List<GameObject>();
    public List<GameObject> thumASMR = new List<GameObject>();
    public List<GameObject> thumSing = new List<GameObject>();
    public List<GameObject> thumTrend = new List<GameObject>();
    public int id, rand;

    private void Awake()
    {
        hits = uploadtxt.GetComponent<Hits>();
    }

    void Start()
    {
        if (((float)Screen.width / Screen.height) > (ScreenWidth / ScreenHeight)) // 가로여백
        {
            Debug.Log("가로");
            createPoint.x = (Screen.width - (Screen.height * ScreenWidth / ScreenHeight)) / 2.0f;
            createPoint.y = createPoint.z = 0.0f;

            scale.x = (Screen.height * ScreenWidth / ScreenHeight) / ScreenWidth;
            scale.y = Screen.height / ScreenHeight;
            scale.z = 1.0f;
        }
        else
        {
            createPoint.y = (Screen.height - (Screen.width * ScreenHeight / ScreenWidth)) / 2.0f;
            createPoint.x = createPoint.z = 0.0f;

            scale.x = Screen.width / ScreenWidth;
            scale.y = (Screen.width * ScreenHeight / ScreenWidth) / ScreenHeight;
            scale.z = 1.0f;
        }

        youtubaButton = GameManager.youtubaButton;

        if (youtubaButton == "")
        {
            adsMaxCnt = 2;
        }
        else if (youtubaButton == "bronze")
        {
            adsMaxCnt = 6;
        }
        else if (youtubaButton == "silver")
        {
            adsMaxCnt = 10;
        }
        else if (youtubaButton == "gold")
        {
            adsMaxCnt = 14;
        }
        else if (youtubaButton == "diamond")
        {
            adsMaxCnt = 20;
        }

        adsNumMax.text = "(최대  " + adsMaxCnt.ToString() + "개)";

    }
    private void OnGUI()
    {
        svMat = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(createPoint, Quaternion.identity, scale);
        GUI.skin = GUISkin;
        if (GUI.Button(new Rect(170.0f, 1060.0f, 750.0f, 100.0f), titleText))
        {
            keyboard_t = TouchScreenKeyboard.Open(titleText);
            chk = 1;
        }
        
        else if(GUI.Button(new Rect(370.0f, 1320.0f, 300.0f, 100.0f), adsText) && !GameTime.tutorialChk)
        {
            type = TouchScreenKeyboardType.NumberPad;
            keyboard_a = TouchScreenKeyboard.Open(adsText, type);
            chk = 2;
        }
        
        if (keyboard_t != null)
        {
            if (keyboard_t.active) tutorialKeyboardChk = false;
            else tutorialKeyboardChk = true;
        }

        GUI.matrix = svMat;

        if (keyboard_t != null && chk == 1)
        {
            titleText = keyboard_t.text;
        }
        else if (keyboard_a != null && chk == 2)
        {
            adsText = keyboard_a.text;
            adsCnt = int.Parse(adsText);

            if (adsCnt > adsMaxCnt)
            {
                adsCnt = adsMaxCnt;
                adsChk = false;
            }
            else adsChk = true;

            adsText = adsCnt.ToString();
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (conceptText == "")
        {
            conceptTextButton.text = "컨셉 ________________________";
        }
        else
        {
            conceptTextButton.text = "컨셉 " + conceptText;

            if (chk2)
            {
                chk2 = false;
                int cnt;
                switch(conceptText)
                {
                    case "토킹":
                        id = 0;
                        cnt = thumTalking.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumTalking[rand].GetComponent<Image>();
                        for(int i=0;i<cnt;i++)
                        {
                            if (i == rand) thumTalking[i].SetActive(true);
                            else thumTalking[i].SetActive(false);
                        }
                        break;

                    case "게임":
                        id = 1;
                        cnt = thumGame.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumGame[rand].GetComponent<Image>();
                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == rand) thumGame[i].SetActive(true);
                            else thumGame[i].SetActive(false);
                        }
                        break;

                    case "먹방":
                        id = 2;
                        cnt = thumEating.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumEating[rand].GetComponent<Image>();
                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == rand) thumEating[i].SetActive(true);
                            else thumEating[i].SetActive(false);
                        }
                        break;

                    case "요리":
                        id =3;
                        cnt = thumCook.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumCook[rand].GetComponent<Image>();
                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == rand) thumCook[i].SetActive(true);
                            else thumCook[i].SetActive(false);
                        }
                        break;

                    case "브이로그":
                        id = 4;
                        cnt = thumVlog.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumVlog[rand].GetComponent<Image>();
                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == rand) thumVlog[i].SetActive(true);
                            else thumVlog[i].SetActive(false);
                        }
                        break;

                    case "ASMR":
                        id = 5;
                        cnt = thumASMR.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumASMR[rand].GetComponent<Image>();
                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == rand) thumASMR[i].SetActive(true);
                            else thumASMR[i].SetActive(false);
                        }
                        break;

                    case "노래":
                        id = 6;
                        cnt = thumSing.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumSing[rand].GetComponent<Image>();
                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == rand) thumSing[i].SetActive(true);
                            else thumSing[i].SetActive(false);
                        }
                        break;

                    case "유행":
                        id = 7;
                        cnt = thumTrend.Count;
                        rand = Random.Range(0, cnt);
                        //hits.thumnailImage = thumTrend[rand].GetComponent<Image>();
                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == rand) thumTrend[i].SetActive(true);
                            else thumTrend[i].SetActive(false);
                        }
                        break;
                }

                for(int i=0;i<thumnailImage.Count;i++)
                {
                    if(i == id)
                    {
                        thumnailImage[i].SetActive(true);
                    }
                    else
                    {
                        thumnailImage[i].SetActive(false);
                    }
                }
            }
            
        }
        
    }
}
