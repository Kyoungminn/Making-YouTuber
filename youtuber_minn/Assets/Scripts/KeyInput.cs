using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyInput : MonoBehaviour
{
    private int chk = 1; //키보드 구분

    //GUI 해상도 따른 위치조정 변수들
    private float ScreenWidth = 1080.0f;
    private float ScreenHeight = 1920.0f;
    private Vector3 scale = Vector2.zero;
    private Vector3 createPoint;
    private Matrix4x4 svMat = Matrix4x4.identity;


    //제목 컨셉 광고
    public string conceptText = "";
    public static string titleText = "g";
    public string adsText = "";
    
    public Text conceptTextButton; //컨셉 _____________ text
    private TouchScreenKeyboard keyboard_t; //제목 키보드
    private TouchScreenKeyboard keyboard_a; //광고 숫자 키보드
    private TouchScreenKeyboardType type; //키보드 타입
    public GUISkin GUISkin; //GUI 종류

    public int adsCnt; //광고개수
    public int adsMaxCnt; //광고최대개수
    public bool adsChk = true; //광고 초과 여부 확인
    public string youtubeButton; //유튜브 버튼

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

    }
    private void OnGUI()
    {

        svMat = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(createPoint, Quaternion.identity, scale);
        GUI.skin = GUISkin;
        if (GUI.Button(new Rect(160.0f, 1010.0f, 750.0f, 100.0f), titleText))
        {
            keyboard_t = TouchScreenKeyboard.Open(titleText);
            chk = 1;
        }
        
        else if (GUI.Button(new Rect(390.0f, 1275.0f, 500.0f, 100.0f), adsText))
        {
            type = TouchScreenKeyboardType.NumberPad;
            keyboard_a = TouchScreenKeyboard.Open(adsText, type);
            chk = 2;
           
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
            
            if(youtubeButton == "노버튼")
            {
                adsMaxCnt = 2;
            }
            else if(youtubeButton == "브론즈")
            {
                adsMaxCnt = 6;
            }
            else if(youtubeButton == "실버")
            {
                adsMaxCnt = 10;
            }
            else if(youtubeButton == "골드")
            {
                adsMaxCnt = 14;
            }
            else if(youtubeButton == "다이아")
            {
                adsMaxCnt = 20;
            }

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
            conceptTextButton.text = "컨셉 ______________________";
        }
        else
        {
            conceptTextButton.text = "컨셉 " + conceptText;
        }
        
    }
}
