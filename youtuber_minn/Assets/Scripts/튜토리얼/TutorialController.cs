using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    KeyInput keyinput;
    public Text title, ads;

    public GameObject OkUpload;
    public GameObject Tuto4_1_2;

    // Start is called before the first frame update
    void Start()
    {
        keyinput = GameObject.Find("GameManager").GetComponent<KeyInput>();
        keyinput.adsText = "1";
    }

    // Update is called once per frame
    void Update()
    {
        if (keyinput.titleText != "" && keyinput.conceptText != "" && keyinput.adsText != "" && keyinput.tutorialKeyboardChk)
        {
            StartCoroutine(waitAminute());
        }

        if(GameManager.uploadChkMain)
        {
            Tuto4_1_2.SetActive(true);
            VideoUploadTime.afterUploadTime = 0.0f;
            GameManager.uploadChkLocker = false;
            GameManager.uploadChkMain = true;

            StartCoroutine(hitRest());
        }
    }

    IEnumerator waitAminute()
    {
        yield return null;
        keyinput.enabled = false;
        title.text = keyinput.titleText;
        ads.text = keyinput.adsText;
        OkUpload.SetActive(true);
    }

    IEnumerator hitRest()
    {
        yield return null;
        Upload_sceneManager.uploadHits[0] = 100;
        Upload_sceneManager.uploadAds[0] = 1;
        Upload_sceneManager.uploadPayoffs[0] = 1000;
    }
}
