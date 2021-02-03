using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalChannel : MonoBehaviour
{
    public GameObject naming;
    TutorialKeyInput tutorialKey;
    string channelName,humanName;
    Text channelCheck;

    // Start is called before the first frame update
    void Start()
    {
        tutorialKey = naming.GetComponent<TutorialKeyInput>();
        channelCheck = gameObject.GetComponent<Text>();

        channelName = tutorialKey.channelText;
        humanName = tutorialKey.nameText;

        channelCheck.text = channelName + " (이)라는\n\n채널을 생성하시겠습니까?";
    }

    public void OnClickChannelOk()
    {
        GameManager.channel_name = channelName;
        GameManager.human_name = humanName;

        SceneManager.LoadScene("Main_scene"); //일단 메인 부르기, 나중에 수정해야함
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
