using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuit : MonoBehaviour
{
    public GameObject Popup;

    // Update is called once per frame
    int ClickCount = 0;
    void Update()
    {
        /* press to start 
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
        */

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
        }

    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

    public void YesButton()
    {
        Application.Quit();
    }

    public void NoButton()
    {
        SoundManager._soundInstance.OnButtonAudio();
        Popup.SetActive(false);
    }

}
