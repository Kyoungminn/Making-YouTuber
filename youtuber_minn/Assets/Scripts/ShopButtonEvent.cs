using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonEvent : MonoBehaviour
{
    public GameObject item, parent, button;
    public int index;

    public void itemActive()    //아이템 입혀보기
    {
        GameObject child;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            child = parent.transform.GetChild(i).gameObject;
            if (item.name.Equals(child.gameObject.name))
            {                
                if (item.activeSelf == false)
                {
                    item.SetActive(true);
                    button.GetComponent<Button>().interactable = true;
                }                   
                else
                {
                    item.SetActive(false);
                    button.GetComponent<Button>().interactable = false;
                }                    
            }                
            else
                child.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
