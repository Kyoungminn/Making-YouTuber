using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConceptInput : MonoBehaviour
{
    Text conceptslt;
    // Start is called before the first frame update
    void Start()
    {
        conceptslt = gameObject.GetComponent<Text>();
    }

    public void OnClickConcept()
    {
        GameObject.Find("GameManager").GetComponent<KeyInput>().conceptText = conceptslt.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
