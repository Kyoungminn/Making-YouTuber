using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VideoUpload : MonoBehaviour
{
    public GameObject uploadDonetxt;  
    public Button deleteButton;
    public Button conceptButton;
    public Button uploadButton;
    public Slider uploading;


    // Start is called before the first frame update
    void Start()
    {
        conceptButton.enabled = true;
        uploading.gameObject.SetActive(false);
        uploadDonetxt.SetActive(false);
    }

    public void UploadClick()
    {
        deleteButton.enabled = false;
        conceptButton.enabled = false;
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
            if(uploading.value < 1f) //업로드중 5초동안
            {
                uploading.value = Mathf.MoveTowards(uploading.value, 1f, Time.deltaTime * (0.2f));
            }
            else //업로드 완료
            {
                uploading.gameObject.SetActive(false);
                uploadDonetxt.SetActive(true);
                deleteButton.enabled = true;
                break;
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
