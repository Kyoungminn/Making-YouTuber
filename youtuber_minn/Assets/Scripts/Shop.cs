using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int money, price;
    public Text moneyTxt, itemTxt, priceTxt;
    public string ItemName, strPrice;

    // Start is called before the first frame update

   
    void Start()
    {
        money = 1000;
        string str = money.ToString();
        moneyTxt.text = (str);
    }

    public void GetName()
    {
        ItemName = this.gameObject.name;
        itemTxt.text = ItemName;
    }

    public void GetPrice()
    {
        string str = GetComponentInChildren<Text>().text;
        priceTxt.text = str;
        price = int.Parse(str);
    }

    public void Buy()
    {
        GameObject PR = GameObject.Find("ItemPrice");
        string str = PR.GetComponent<Text>().text;
        price = int.Parse(str);
        money -= price;
        if(money < 0)
        {
            money += price;
            //돈 부족하다고 팝업
        }
        str = "" + money;
        moneyTxt.text = (str);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void buy()
    {

    }
}
