using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClickPrefab()
    {
        SoundManager._soundInstance.OnButtonAudio();
        Destroy(gameObject);
    }

    //게임종료때 사용할 함수들
    public void GameQuit_YesButton()
    {
        Destroy(gameObject);
        Application.Quit();
    }

    public void GameQuit_NoButton()
    {
        GameObject.Find("GameQuit").GetComponent<GameQuit>().clickCnt = 0;
        SoundManager._soundInstance.OnButtonAudio();
        Destroy(gameObject);
    }
    //
}
