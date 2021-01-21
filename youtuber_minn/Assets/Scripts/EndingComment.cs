using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingComment : MonoBehaviour
{
    Text comment;
    public List<string> commentTexts = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        comment = gameObject.GetComponent<Text>();
        StartCoroutine(Comments());
    }

    IEnumerator Comments()
    {
        while(true)
        {
            int rand = Random.Range(0, commentTexts.Count);
            comment.text = commentTexts[rand];
            yield return new WaitForSeconds(1.0f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
