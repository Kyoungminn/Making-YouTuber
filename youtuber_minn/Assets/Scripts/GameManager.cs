using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject UploadPanel;

    void Start()
    {
        
    }

    void Update()
    {
    
    }

    public void OpenPanel()
    {
        UploadPanel.SetActive(true);
    }

    public void ExitPanel()
    {
        UploadPanel.SetActive(false);
    }
}
