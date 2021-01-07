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
    private Matrix4x4 svMat = Matrix4x4.identity;

    //제목 컨셉 광고
    public string conceptText = "";
    public string titleText = "";
    public string adsText = "";
    
    public Text conceptTextButton;
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
        
    }
    private void OnGUI()
    {
        scale.x = Screen.width / ScreenWidth;
        scale.y = Screen.height / ScreenHeight;
        scale.z = 1.0f;

        svMat = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
        GUI.skin = GUISkin;
        if (GUI.Button(new Rect(160, 1010, 750, 100), titleText))
        {
            keyboard_t = TouchScreenKeyboard.Open(titleText);
            chk = 1;
        }
        
        else if (GUI.Button(new Rect(400, 1275, 500, 100), adsText))
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
            conceptTextButton.text = "컨셉 _________________";
        }
        else
        {
            conceptTextButton.text = "컨셉 " + conceptText;
        }
        
    }
}
