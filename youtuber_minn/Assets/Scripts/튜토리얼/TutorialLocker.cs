using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLocker : MonoBehaviour
{
    public Image thumb1, thumb2;
    public Text thumbText;

    public GameObject main1, locker1;

    // Start is called before the first frame update
    void Start()
    {
        thumb1.sprite = Upload_sceneManager.uploadThumnail[0].sprite;
        thumb1.color = Upload_sceneManager.uploadThumnail[0].color;
        thumb2.sprite = Upload_sceneManager.uploadThumnailImage[0].sprite;
        thumbText.text = "제목: " + Upload_sceneManager.uploadTitles[0] + "\n조회수: " + Upload_sceneManager.uploadHits[0].ToString();
    }

    public void MainToLocker()
    {
        main1.SetActive(true);
        StartCoroutine(timeWait());
        
    }

    IEnumerator timeWait()
    {
        yield return new WaitForSeconds(1.0f);
        main1.SetActive(false);
        locker1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
