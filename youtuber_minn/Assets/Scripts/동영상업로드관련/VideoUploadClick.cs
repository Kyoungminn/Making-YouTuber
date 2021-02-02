using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoUploadClick : MonoBehaviour
{
    public List<GameObject> impossiblePopup = new List<GameObject>();
    public List<GameObject> impossibleLive = new List<GameObject>();

    public Text impossibleUploadTime;
    public Text impossibleLiveTime;

    public void onVideoUploadClick()
    {
        if(GameManager.health > 20 && VideoUploadTime.afterUploadTime == 0.0f)
        {
            SceneManager.LoadScene("Upload_scene");
        }
        else if(GameManager.health <= 20)
        {
            impossiblePopup[0].SetActive(true);
        }
        else
        {
            impossiblePopup[1].SetActive(true);
        }
    }

    public void onLiveClick()
    {
        if (GameManager.health > 50 && VideoUploadTime.afterLiveTime == 0.0f)
        {
            SceneManager.LoadScene("Live_scene");
        }
        else if (GameManager.health <= 50)
        {
            impossibleLive[0].SetActive(true);
        }
        else
        {
            impossibleLive[1].SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (impossiblePopup[1])
        {
            float time = VideoUploadTime.afterUploadTime;
            impossibleUploadTime.text = ((int)time / 60).ToString() + " : " + ((int)time % 60).ToString("D2");
        }
        
        if (impossibleLive[1])
        {
            float time = VideoUploadTime.afterLiveTime;
            impossibleLiveTime.text = ((int)time / 60).ToString() + " : " + ((int)time % 60).ToString("D2");
        }

        
    }
}
