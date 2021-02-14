using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLocker : MonoBehaviour
{
    public Image thumb1;
    public GameObject thumb2;
    public Text thumbText;

    public GameObject main1, locker1;

    // Start is called before the first frame update
    void Start()
    {
        thumb1.color = new Color(Upload_sceneManager.uploadThumnail_r[0],
                                   Upload_sceneManager.uploadThumnail_g[0],
                                   Upload_sceneManager.uploadThumnail_b[0]);
        for (int i = 0; i < 24; i++)
        {
            int pr = i / 3;
            int chd = i % 3;
            if (i == Upload_sceneManager.uploadThumnailImage[0])
            {
                Debug.Log(thumb2.transform.GetChild(pr).transform.GetChild(chd).name);
                thumb2.transform.GetChild(pr).transform.GetChild(chd).gameObject.SetActive(true);
            }
            else
            {
                thumb2.transform.GetChild(pr).transform.GetChild(chd).gameObject.SetActive(false);
            }
        }
        thumbText.text = Upload_sceneManager.uploadTitles[0] + "\n조회수: " + Upload_sceneManager.uploadHits[0].ToString();
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
