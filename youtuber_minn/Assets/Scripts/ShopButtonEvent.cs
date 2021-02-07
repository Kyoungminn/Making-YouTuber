using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonEvent : MonoBehaviour
{
    public struct itemCode
    {
        public int panel;
        public int btn;
    }


    public GameObject item, parent, button, itemCollection; //아이템이미지, 상위카테고리, 구매버튼, 최상위카테고리
    public int index;
    public Text totalTxt;   

    public static itemCode[] code = new itemCode[4];

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

    public string GetTotal()
    {
        GameObject child, child2;
        GameObject go;
        int total=0, price;
        string str;
        string[] spstring;
        for (int i = 0; i < itemCollection.transform.childCount; i++)   //활성화된 아이템을 찾아서
        {                                                               //해당 아이템 오브젝트에서 가격가져와서 합산
            child = itemCollection.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                if (child2.activeSelf == true)
                {
                    str = child2.name;
                    spstring = str.Split('_');                  //_img 뗀 게임 오브젝트 네임으로 찾아서 그 가격을 가져옴
                    str = spstring[0];
                    go = GameObject.Find(str);
                    if(go == null)
                    {
                        Debug.Log(str+" 못찾음");
                    }
                    str = go.GetComponentInChildren<Text>().text;
                    price = int.Parse(str);
                    total += price;
                }                   
            }
        }        
        return total.ToString();
    }

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalTxt.text = GetTotal();
    }

}
