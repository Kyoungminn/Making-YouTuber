﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupChange : MonoBehaviour
{
    GameObject uploadbutton;
    public GameObject conceptBox;
    public GameObject canvas, prefabConcept;
    public void ConceptChange()
    {
        if (uploadbutton.activeSelf == true)
        {
            GameObject.Find("GameManager").GetComponent<KeyInput>().enabled = false;
            Vector3 creatingpoint = canvas.transform.localPosition;
            conceptBox = Instantiate(prefabConcept, creatingpoint, Quaternion.identity) as GameObject;
        }
        
    }

    public void ConceptDelete()
    {
        GameObject.Find("GameManager").GetComponent<KeyInput>().enabled = true;
        Destroy(prefabConcept);
    }

    public void ConceptBoxDelete()
    {
        GameObject.Find("GameManager").GetComponent<KeyInput>().enabled = true;
        Destroy(conceptBox);
    }

    // Start is called before the first frame update
    void Start()
    {
        uploadbutton = GameObject.Find("UploadButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
