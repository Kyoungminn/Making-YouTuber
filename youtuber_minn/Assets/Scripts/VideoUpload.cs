using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VideoUpload : MonoBehaviour
{
    KeyInput keyinput;
    public Button uploadButton;
    public Slider uploading;
    public Text uploadDone;

    //컨셉 종류 카운트
    public Dictionary<string, int> conceptCnt = new Dictionary<string, int>();
  
    // Start is called before the first frame update
    void Start()
    {
        keyinput = GameObject.Find("GameManager").GetComponent<KeyInput>();

        uploading.gameObject.SetActive(false);
        uploadDone.gameObject.SetActive(false);
    }

    public void UploadClick()
    {
        //업로드 눌렀을 시 컨셉개수카운트
        if (!conceptCnt.ContainsKey(keyinput.conceptText))
        {
            conceptCnt.Add(keyinput.conceptText, 1);
        }
        else
        {
            conceptCnt[keyinput.conceptText]++;
        }
        Debug.Log(keyinput.conceptText);
        Debug.Log(conceptCnt[keyinput.conceptText]);
        //

        uploadButton.gameObject.SetActive(false);
        uploading.gameObject.SetActive(true);
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return null;
        while(uploading.value <= 1f)
        {
            yield return null;
            if(uploading.value < 1f)
            {
                uploading.value = Mathf.MoveTowards(uploading.value, 1f, Time.deltaTime * (0.2f));
            }
            else
            {
                uploading.gameObject.SetActive(false);
                uploadDone.gameObject.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
