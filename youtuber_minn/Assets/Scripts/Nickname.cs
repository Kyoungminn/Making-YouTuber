using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nickname : MonoBehaviour
{
    public InputField nickname;
    public GameObject Bronze;
    public GameObject Silver;
    public GameObject Gold;
    public GameObject Diamond;
    public GameObject Ruby;

    public static int membershipIdx = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.nickname = nickname.text;

        if (GameManager.subscriber >= 10000 && GameManager.charm >= 100 && membershipIdx == 1)
        {
            membershipIdx++;
            SoundManager._soundInstance.PopupAudio();
            Bronze.SetActive(true);
            GameManager.youtubaButton = GameManager.button_name[1];

        }
        if (GameManager.subscriber >= 100000 && GameManager.charm >= 300 && membershipIdx == 2)
        {
            membershipIdx++;
            SoundManager._soundInstance.PopupAudio();
            Silver.SetActive(true);
            GameManager.youtubaButton = GameManager.button_name[2];

        }
        if (GameManager.subscriber >= 1000000 && GameManager.charm >= 500 && membershipIdx == 3) 
        {
            membershipIdx++;
            SoundManager._soundInstance.PopupAudio();
            Gold.SetActive(true);
            GameManager.youtubaButton = GameManager.button_name[3];

        }
        if (GameManager.subscriber >= 10000000 && GameManager.charm >= 700 && membershipIdx == 4) 
        {
            membershipIdx++;
            SoundManager._soundInstance.PopupAudio();
            Diamond.SetActive(true);
            GameManager.youtubaButton = GameManager.button_name[4];
        }
        if (GameManager.subscriber >= 50000000 && GameManager.charm >= 1000 && membershipIdx == 5)
        {
            membershipIdx++;
            SoundManager._soundInstance.PopupAudio();
            Ruby.SetActive(true);
            GameManager.youtubaButton = GameManager.button_name[5];

        }
    
    }
}
