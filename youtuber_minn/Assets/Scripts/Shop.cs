using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int money, price, price2, total=0;
    public Text moneyTxt, itemTxt, priceTxt;
    public string ItemName, strPrice;
    public GameObject parent;

    // Start is called before the first frame update
   
    void Start()
    {
        //money = GameManager.money;
        money = 1000;
        string str = money.ToString();
        moneyTxt.text = (str);
    }

    public void GetName_Beauty()    
    {
        if (itemTxt.text.Equals(this.gameObject.name))
        {
            itemTxt.text = "";
        }
        else
        {
            ItemName = this.gameObject.name;
            itemTxt.text = ItemName;
        }       
       
    }

    public void GetName()
    {
        ItemName = this.gameObject.name;
        itemTxt.text = ItemName + "을(를)";
    }

    public void GetPrice_Beauty()      //total계산
    {
        GameObject go;
        string str = GetComponentInChildren<Text>().text;   //버튼에 해당하는 item의 가격 가져옴
        price = int.Parse(str);
        if (itemTxt.text.Equals(this.gameObject.name))      //현재 itemTxt에 있는 문자열과 버튼에 해당하는 itme name이 같다면
        {
            total += price;                                 //total에서 버튼의 item가격을 뺀다
        }
        else if (itemTxt.text == "")                        //현재 itemTxt에 있는 문자열이 없다면 total에서 
        {
            total -= price;
        }
        else                                                //어느 것도 해당안된다면(itemTxt에 다른 itme name이 들어가 있다면)
        {
            go = GameObject.Find(itemTxt.text);             //itemTxt에 해당하는 game object를 찾아서
            if(go == null)
            {
                Debug.Log("못찾음");
            }
            else
            {                
                str = go.GetComponentInChildren<Text>().text;   //가격을 구한뒤
                Debug.Log(go.name + " 찾음  가격 : " + str);
                price2 = int.Parse(str);
                total = total - price + price2;                 //버튼에 해당하는 itme값을 더하고 다른 itme의 값을 뺀다
            }
        }
        priceTxt.text = total.ToString();
    }

    public void GetPrice()      //total계산
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
        GameObject PR = GameObject.Find("Total");
        string str = PR.GetComponent<Text>().text;
        price = int.Parse(str);
        money -= price;
        if (money < 0)
        {
            money += price;
            //돈 부족하다고 팝업
        }
        str = "" + money;
        moneyTxt.text = (str);
        GameManager.money = money;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void buy()
    {

    }
}
