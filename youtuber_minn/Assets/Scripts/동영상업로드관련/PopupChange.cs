using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupChange : MonoBehaviour
{
    GameObject uploadbutton;
    GameObject gameMangager;
    public GameObject conceptBox;
    public GameObject canvas, prefabConcept;
    public void ConceptChange()
    {
        gameMangager.GetComponent<KeyInput>().enabled = false;
        Vector3 creatingpoint = canvas.transform.localPosition;
        conceptBox = Instantiate(prefabConcept, creatingpoint, Quaternion.identity) as GameObject;
    }

    public void ConceptDelete()
    {
        gameMangager.GetComponent<KeyInput>().enabled = true;
        Destroy(prefabConcept);
    }

    public void ConceptBoxDelete()
    {
        gameMangager.GetComponent<KeyInput>().enabled = true;
        Destroy(conceptBox);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameMangager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
