using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerVideo : MonoBehaviour
{
    Text info;
    // Start is called before the first frame update
    void Start()
    {
        info = gameObject.GetComponent<Text>();
        info.text = "제목: " + KeyInput.titleText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
