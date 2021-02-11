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


    //이름 채널명, 키보드에 입력한 것이 저장될 string 변수
    public string nameText = "";
    public string channelText = "";

    private TouchScreenKeyboard keyboard_n; //이름 키보드
    private TouchScreenKeyboard keyboard_c; //채널명 키보드
    private TouchScreenKeyboardType type; //키보드 타입
    public GUISkin GUISkin; //GUI 종류

    void Start()
    {
        //GUI 해상도 맞추는 부분
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
        //

    }
    private void OnGUI()
    {
        //GUI 해상도 맞추는 부분
        svMat = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(createPoint, Quaternion.identity, scale);
        GUI.skin = GUISkin;
        //

        //이름 버튼
        if (GUI.Button(new Rect(420.0f,770.0f, 355.0f, 90.0f), nameText))
        {
            keyboard_n = TouchScreenKeyboard.Open(nameText);
            chk = 1; //키보드가 2개 이상이라서 chk변수가 필요했습니다 키보드가 1개라면 필요 없을 것 같아요!
        }

        //채널명 버튼
        else if (GUI.Button(new Rect(420.0f, 910.0f, 355.0f, 90.0f), channelText))
        {
            //type = TouchScreenKeyboardType.NumberPad;
            keyboard_c = TouchScreenKeyboard.Open(channelText);
            chk = 2;

        }

        GUI.matrix = svMat;

        if (keyboard_n != null && chk == 1)
        {
            SoundManager._soundInstance.KeyboardAudio();
            if (keyboard_n.text.Length > 10) //글자 수에 10글자 제한이 있어서 추가한 if문
            {
                nameText = keyboard_n.text.Substring(0,10);
            }
            else nameText = keyboard_n.text; //글자 수 제한 없으면 이 부분만 필요해요
        }
        else if (keyboard_c != null && chk == 2)
        {
            SoundManager._soundInstance.KeyboardAudio();
            if (keyboard_c.text.Length > 10)
            {
                channelText = keyboard_c.text.Substring(0,10);
            }
            else channelText = keyboard_c.text;
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
