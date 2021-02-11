﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int money, price;
    public Text moneyTxt, priceTxt, itemTxt;
    public string ItemName;
    public static int panel, btn;
    // Start is called before the first frame update

    void Start()
    {
        money = GameManager.money;
        //money = 1000000;
        string str = money.ToString();
        moneyTxt.text = (str);
    }

    public void GetName_Beauty()    //매력탭에서 사용되는 아이템 이름 표시
    {
        GameObject go;
        string str;
        string[] spstring;

        GameObject parent = transform.parent.gameObject;       //item의 index 구하기
        str = parent.gameObject.name;
        spstring = str.Split('-');
        //Debug.Log(spstring[0] + "    " + spstring[1]);
        str = spstring[1];
        panel = int.Parse(str);

        if (itemTxt.text.Equals(this.gameObject.name))
        {
            itemTxt.text = "";
        }
        else
        {
            ItemName = this.gameObject.name;
            itemTxt.text = ItemName;
        }


        for (int i = 0; i < parent.transform.childCount; i++)       //btn 알아내기
        {
            go = parent.transform.GetChild(i).gameObject;
            if (go.name.Equals(this.gameObject.name))
            {
                btn = i;
                break;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            /*if (ShopButtonEvent.code[i].panel == panel && ShopButtonEvent.code[i].btn == btn)
            {
                ShopButtonEvent.code[i].panel = 0;
                ShopButtonEvent.code[i].btn = 0;
            }*/
            //else
            //{
                if (panel >= 2 && panel < 8)         //itemCode에 각각 저장([0]: 머리, [1]: 상의, [2]:하의, [3]: 신발)
                {
                    ShopButtonEvent.code[0].panel = panel;
                    ShopButtonEvent.code[0].btn = btn;
                }
                else if ((panel >= 8 && panel < 13) || (panel == 7 && btn == 2) || (panel == 13 && btn == 0) || (panel >= 16 && panel < 20) )         //itemCode에 각각 저장([0]: 머리, [1]: 상의, [2]:하의, [3]: 신발)
                {
                    ShopButtonEvent.code[1].panel = panel;
                    ShopButtonEvent.code[1].btn = btn;
                }
                else if (panel >= 20 && panel < 23)         //itemCode에 각각 저장([0]: 머리, [1]: 상의, [2]:하의, [3]: 신발)
                {
                    ShopButtonEvent.code[2].panel = panel;
                    ShopButtonEvent.code[2].btn = btn;
                }
                else if ((panel >= 13 && panel < 16) || (panel == 16 && btn == 0))         //itemCode에 각각 저장([0]: 머리, [1]: 상의, [2]:하의, [3]: 신발)
                {
                    ShopButtonEvent.code[3].panel = panel;
                    ShopButtonEvent.code[3].btn = btn;
                    //Debug.Log("현재  ShopButtonEvent.code[3].panel : " + ShopButtonEvent.code[3].panel + ", ShopButtonEvent.code[3].btn : " + ShopButtonEvent.code[3].btn);
                }
            //}
        }
    }

    public void ItemInfo_Beauty()       //매력탭에서 사용되는 아이템 이름을 팝업에 띄우는 함수
    {
        /*GameObject go, go2;
        string str, str2;
        go = GameObject.Find("Hair");
        str = go.GetComponent<Text>().text;
        go2 = GameObject.Find("T");
        str2 = go2.GetComponent<Text>().text;
        if(str != "" && str2 != "")
        {
            ItemName = str + ", " + str2;
        }
        else
        {
            if(str == "")
            {
                ItemName = str2;
            }
            else
            {
                ItemName = str;
            }
        }*/
        itemTxt.text = "착용하신 아이템들을";              
    }

    public void GetName()
    {        
        string str;
        string[] spstring;

         GameObject parent = transform.parent.gameObject;       //item의 index 구하기
         str = parent.gameObject.name;
         spstring = str.Split('-');
         str = spstring[1];
         panel = int.Parse(str);

        str = this.gameObject.name;
        spstring = str.Split('_');
        ItemName = spstring[0];
        str = spstring[1];
        btn = int.Parse(str);

        itemTxt.text = ItemName + "을(를)";

    }

    public void GetPrice()          
    {
        string str = GetComponentInChildren<Text>().text;   //버튼에 해당하는 item의 가격 가져옴
        price = int.Parse(str);
        priceTxt.text = price.ToString();
    }
    
    public void ActiveItemIfo()
    {
        GetName();
        GetPrice();
    }

    public void Buy()
    {
        GameObject go1 = GameObject.Find("편집items");    //각각 편집, 건강 items구분 해주는 변수
        GameObject go2 = GameObject.Find("건강itmes");
        GameObject PR = GameObject.Find("ItemPrice");
        string str = PR.GetComponent<Text>().text;
        price = int.Parse(str);
        money -= price;
        if (money < 0)
        {
            money += price; 
            GameObject.Find("Canvas").transform.Find("구매불가능").gameObject.SetActive(true);
        }
        else
        {
            str = "" + money;
            moneyTxt.text = (str);
            GameManager.money = money;
            if (go2 == null)
            {
                ItemLocker.EditItems[panel, btn]++;      //편집 아이템 구매하면 개수++
            }
            if (go1 == null)
            {
                ItemLocker.HealthItems[panel, btn]++;      //건강 아이템 구매하면 개수++
            }
        }       
    }

    public void Buy_Beauuty()
    {
        GameObject PR = GameObject.Find("ItemPrice");
        string str = PR.GetComponent<Text>().text;
        price = int.Parse(str);
        money -= price;
        if (money < 0)
        {
            money += price;
            GameObject.Find("Canvas").transform.Find("구매불가능").gameObject.SetActive(true);
        }
        else
        {
            str = "" + money;
            moneyTxt.text = (str);
            GameManager.money = money;
            for (int i = 0; i < 4; i++)
            {
                //Debug.Log("(2) 현재  ShopButtonEvent.code["+i+ "].panel : " + ShopButtonEvent.code[i].panel + ", ShopButtonEvent.code[" + i + "].btn : " + ShopButtonEvent.code[i].btn);
                if (ShopButtonEvent.code[i].panel == 0 && ShopButtonEvent.code[i].btn == 0)
                    continue;
                ItemLocker.CharmItems[ShopButtonEvent.code[i].panel, ShopButtonEvent.code[i].btn]++;        //아이템 구매하면 개수++  
                                                                                                            // Debug.Log("현재 CharmItemes[" + ShopButtonEvent.code[i].panel + "," + ShopButtonEvent.code[i].btn + "] : " + ItemLocker.CharmItems[ShopButtonEvent.code[i].panel, ShopButtonEvent.code[i].btn]);
            }
            for (int i = 0; i < 4; i++)
            {
                ShopButtonEvent.code[i].panel = ShopButtonEvent.code[i].btn = 0;    //아이템 사고나면 담아뒀던 code 초기화
            }
            GameObject parent = GameObject.Find("현재아이템");
            for (int i = 2; i < parent.transform.childCount; i++)   
            {
                PR = parent.transform.GetChild(i).gameObject;   //현재아이템 표시도 초기화
                PR.GetComponent<Text>().text = "";
            }
            parent = GameObject.Find("아이템");
            GameObject child;
            for (int i = 0; i < parent.transform.childCount; i++)   //입고있는 아이템도 벗음
            {
                PR = parent.transform.GetChild(i).gameObject;
                for (int j = 0; j < PR.transform.childCount; j++)
                {
                    child = PR.transform.GetChild(j).gameObject;
                    child.SetActive(false);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void buy()
    {

    }
}
