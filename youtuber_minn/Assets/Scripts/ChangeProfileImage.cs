using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProfileImage : MonoBehaviour
{
  
    public Image test_middle;
    public Sprite test_sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeImage()
    {
        test_middle.sprite = test_sprite;
    }
}
