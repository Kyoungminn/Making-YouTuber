using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public void onStartButton()
    {
        if(GameTime.tutorialChk)
        {
            SceneManager.LoadScene("Tutorial_scene");
        }
        else
        {
            SceneManager.LoadScene("Main_scene");
        }
    }
}
