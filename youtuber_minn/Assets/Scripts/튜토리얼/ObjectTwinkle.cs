using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTwinkle : MonoBehaviour
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            obj.GetComponent<Image>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            obj.GetComponent<Image>().enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
