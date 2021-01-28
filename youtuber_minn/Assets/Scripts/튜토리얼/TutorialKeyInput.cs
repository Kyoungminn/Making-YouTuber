using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialKeyInput : MonoBehaviour
{
    private int chk = 1; //키보드 구분

    //GUI 해상도 따른 위치조정 변수들
    private float ScreenWidth = 1080.0f;
    private float ScreenHeight = 1920.0f;
    private Vector3 scale = Vector2.zero;
    private Vector3 createPoint;
    private Matrix4x4 svMat = Matrix4x4.identity;


    //이름 채널명
    public string nameText = "";
    public string channelText = "";

    private TouchScreenKeyboard keyboard_n; //이름 키보드
    private TouchScreenKeyboard keyboard_c; //채널명 키보드
    private TouchScreenKeyboardType type; //키보드 타입
    public GUISkin GUISkin; //GUI 종류

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
        if (GUI.Button(new Rect(430.0f,770.0f, 350.0f, 90.0f), nameText))
        {
            keyboard_n = TouchScreenKeyboard.Open(nameText);
            chk = 1;
        }

        else if (GUI.Button(new Rect(430.0f, 900.0f, 350.0f, 90.0f), channelText))
        {
            //type = TouchScreenKeyboardType.NumberPad;
            keyboard_c = TouchScreenKeyboard.Open(channelText);
            chk = 2;

        }

        GUI.matrix = svMat;

        if (keyboard_n != null && chk == 1)
        {
            if (keyboard_n.text.Length > 10)
            {
                nameText = keyboard_n.text.Substring(0,9);
            }
            else nameText = keyboard_n.text;
        }
        else if (keyboard_c != null && chk == 2)
        {
            if (keyboard_c.text.Length > 10)
            {
                channelText = keyboard_c.text.Substring(0,9);
            }
            else channelText = keyboard_c.text;
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
