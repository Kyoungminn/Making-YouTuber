using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyping : MonoBehaviour
{
    Text typingText;
    string typing;
    bool chk = true;

    public void OnClickNextButton()
    {
        typingText.text = typing;
        chk = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        chk = true;
        typingText = GetComponent<Text>();
        typing = typingText.text;
        typingText.text = "";
        StartCoroutine(TypingText());
    }

    public IEnumerator TypingText()
    {
        int i = 0;
        while (i < typing.Length && chk)
        {
            typingText.text += typing[i++];
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
