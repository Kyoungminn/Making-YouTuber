﻿using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.nickname = nickname.text;

         if (GameManager.subscriber >= 10000 && GameManager.charm >= 100)
        {
            SoundManager._soundInstance.PopupAudio();
           Bronze.SetActive(true);
            
        }
        if (GameManager.subscriber >= 100000 && GameManager.charm >= 300)
        {
            SoundManager._soundInstance.PopupAudio();
            Silver.SetActive(true);
            
        }
        if (GameManager.subscriber >= 1000000 && GameManager.charm >= 500)
        {
            SoundManager._soundInstance.PopupAudio();
            Gold.SetActive(true);
            
        }
        if (GameManager.subscriber >= 10000000 && GameManager.charm >= 700)
        {
            SoundManager._soundInstance.PopupAudio();
            Diamond.SetActive(true);
        }
        if (GameManager.subscriber >= 50000000 && GameManager.charm >= 1000)
        {
            SoundManager._soundInstance.PopupAudio();
            Ruby.SetActive(true);
            
        }
    
    }
}
