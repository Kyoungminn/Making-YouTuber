using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailColor : MonoBehaviour
{
    public Image thumbnail;
    Color thumbnailBg;

    public void OnTumbnailColorButton()
    {
        thumbnail.color = thumbnailBg;
    }

    // Start is called before the first frame update
    void Start()
    {
        thumbnailBg = gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
