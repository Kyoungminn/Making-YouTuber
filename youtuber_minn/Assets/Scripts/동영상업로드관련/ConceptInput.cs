using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConceptInput : MonoBehaviour
{
    GameObject gamemanager;
    Text conceptslt;
    // Start is called before the first frame update
    void Start()
    {
        conceptslt = gameObject.GetComponent<Text>();
        gamemanager = GameObject.Find("GameManager");
    }

    public void OnClickConcept()
    {
        gamemanager.GetComponent<KeyInput>().conceptText = conceptslt.text;
        gamemanager.GetComponent<KeyInput>().chk2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
