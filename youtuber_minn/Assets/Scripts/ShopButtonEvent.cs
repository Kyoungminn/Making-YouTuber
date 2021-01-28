using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonEvent : MonoBehaviour
{
    public GameObject item, parent, button, itemCollection; //아이템이미지, 상위카테고리, 구매버튼, 최상위카테고리
    public int index;    
   

public void itemActive()    //아이템 입혀보기
    {
        GameObject child, child2;
        bool boolean = false;
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
                }                    
            }                
            else
                child.SetActive(false);
        }
        for (int i = 0; i < itemCollection.transform.childCount; i++)   //활성화된 아이템이 없으면 button false
        {
            child = itemCollection.transform.GetChild(i).gameObject;
            for(int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                if (child2.activeSelf == true)
                    boolean = true;
            }

        }
        if(boolean == false)
            button.GetComponent<Button>().interactable = false;
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
