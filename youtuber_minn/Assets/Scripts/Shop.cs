using System.Collections;
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
        //money = 1000;
        string str = money.ToString();
        moneyTxt.text = (str);

        GameObject editgo = GameObject.Find("편집items");
    }

    public void GetName_Beauty()    //매력탭에서 사용되는 아이템 이름 표시
    {
        GameObject go;
        string str;
        string[] spstring;
        if (itemTxt.text.Equals(this.gameObject.name))
        {
            itemTxt.text = "";
        }
        else
        {
            ItemName = this.gameObject.name;
            itemTxt.text = ItemName;
        }

        GameObject parent = transform.parent.gameObject;       //item의 index 구하기
        str = parent.gameObject.name;
        spstring = str.Split('-');
        Debug.Log(spstring[0] + "    " + spstring[1]);
        str = spstring[1];
        panel = int.Parse(str);

        for (int i = 0; i < parent.transform.childCount; i++)
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
            if (ShopButtonEvent.code[i].panel == panel && ShopButtonEvent.code[i].btn == btn)
            {
                ShopButtonEvent.code[i].panel = 0;
                ShopButtonEvent.code[i].btn = 0;
            }
            else
            {
                if (panel >= 2 && panel < 8)         //itemCode에 각각 저장([0]: 머리, [1]: 상의, [2]:하의, [3]: 신발)
                {
                    ShopButtonEvent.code[0].panel = panel;
                    ShopButtonEvent.code[0].btn = btn;
                }
            }
        }
    }

    public void ItemInfo_Beauty()       //매력탭에서 사용되는 아이템 이름을 팝업에 띄우는 함수
    {
        GameObject go, go2;
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
        }
        itemTxt.text = ItemName + "을(를)";              
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
        if(go1 != null)
        {
            Debug.Log("go1(편집items)찾음");
        }
        else
        {
            Debug.Log("go1(편집items)못 찾음");
        }
        if (go2 == null)
        {
            Debug.Log("go2(건강items)못 찾음");
        }
        else
        {
            Debug.Log("go2(건강items)찾음");
        }
        string str = PR.GetComponent<Text>().text;
        price = int.Parse(str);
        money -= price;
        if (money < 0)
        {
            money += price;
            //돈 부족하다고 팝업
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
            //돈 부족하다고 팝업
        }
        else
        {
            str = "" + money;
            moneyTxt.text = (str);
            GameManager.money = money;
            for(int i = 0; i < 4; i++)
            {
                ItemLocker.CharmItems[ShopButtonEvent.code[i].panel, ShopButtonEvent.code[i].btn]++;        //아이템 구매하면 개수++   
            }                                     
        }
        Debug.Log(ItemLocker.CharmItems[2,1]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void buy()
    {

    }
}
