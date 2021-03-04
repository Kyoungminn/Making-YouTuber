using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuit : MonoBehaviour
{
    public GameObject prefabGameQuit;
    GameObject par;

    void Start()
    {
        par = GameObject.Find("Canvas");    
    }
    // Update is called once per frame
    //int ClickCount = 0;
    void Update()
    {
        /* 더블클릭 누르면 뜨게하기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            ClickCount = 0;
            CancelInvoke("DoubleClick");
            SoundManager._soundInstance.PopupAudio();
            Popup.SetActive(true);
        }*/

        //한번 눌러도 뜨게하기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager._soundInstance.PopupAudio();
            GameObject child = Instantiate(prefabGameQuit) as GameObject;
            child.transform.SetParent(par.transform);
            child.transform.localPosition = par.transform.localPosition;
            child.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }


    }

    /*void DoubleClick()
    {
        ClickCount = 0;
    
    public void YesButton()
    {
        Application.Quit();
    }

    public void NoButton()
    {
        SoundManager._soundInstance.OnButtonAudio();
        Popup.SetActive(false);
    }
    */

}
