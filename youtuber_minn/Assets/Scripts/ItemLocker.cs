using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLocker : MonoBehaviour
{
    public static int[] Index = new int[6];             //매력아이템 index
    public static int[,] HealthItems = new int[4,3];
    public static int[,]  CharmItems = new int[30, 3];
    public static int[,] EditItems = new int[30, 3];
    public GameObject HI, EI, CI, parent, item, button, itemCollection; 
    public Text itemTxt, statTxt;


    GameObject child, child2, Count;
    string str;
    static int panel, btn, stat, maxHealth = 100;  // maxEdit, maxCharm, ;

    public void useItem()
    {
        //Debug.Log("현재 stat : " + stat);       
        if (GameManager.health < maxHealth)
        {
            HealthItems[panel, btn]--;
            GameManager.health += stat;
            if (GameManager.health > maxHealth)
                GameManager.health = maxHealth;
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("사용불가팝업").gameObject.SetActive(true);
        }
    }

    /*public void useItem_edit()
    {        //Debug.Log("현재 edit stat : " + stat);      
        if (GameManager.edit < maxEdit)
        {
            EditItems[panel, btn]--;
            GameManager.edit += stat;
            if (GameManager.edit > maxEdit)
                GameManager.edit = maxEdit;
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("사용불가팝업").gameObject.SetActive(true);
        }
    }*/

    public void GetName_Beauty()
    {
        string ItemName;
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
    public void GetName()       //건강 아이템 클릭시 이름 가져오기
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
        str = spstring[1];
        btn = int.Parse(str);

        str = spstring[0];
        itemTxt.text = str + "을(를)";
    }

    public void GetStat()       //건강 아이템 클릭시 스탯 가져오기
    {
        string str = GetComponentInChildren<Text>().text;   //버튼에 해당하는 item의 스탯 가져옴
        string[] spstring = str.Split('+');
        statTxt.text = "+" + spstring[1];
        stat = int.Parse(spstring[1]);
    }
    public void GetCharming()
    {
        //GameObject child, child2;
        //GameObject go;
        //int charming = 0;
        //string str;
        //string[] spstring;
        /*for (int i = 0; i < itemCollection.transform.childCount; i++)   //활성화된 아이템을 찾아서
        {                                                               //해당 아이템 오브젝트에서 매력 가져와서 합산
            child = itemCollection.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                if (child2.activeSelf == true)
                {                    
                    str = child2.name;
                    spstring = str.Split('_');
                    str = spstring[0];
                    go = GameObject.Find(str);
                    if(go == null)
                    {
                        Debug.Log(str + " 못 찾음");
                        break;
                    }
                    else
                    {
                        Debug.Log(str + " 찾음");
                    }
                    str = go.GetComponentInChildren<Text>().text;
                    spstring = str.Split('+');
                    charming += int.Parse(spstring[1]);
                    
                }
            }
        }*/
        /*if (charming > maxCharm)
        {
            GameObject.Find("Canvas").transform.Find("착용불가팝업").gameObject.SetActive(true);
        }*/

        for (int i = 0; i < itemCollection.transform.childCount; i++)   //활성화된 아이템을 찾아서
        {                                                               //인덱스 저장
            child = itemCollection.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                if (child2.activeSelf == true)
                {
                    Index[i] = j;
                }
            }
        }
        //GameManager.charm = charming;
        //GameObject go2;
        //go2 = GameObject.Find("MyGMCharmStat");
        //go2.GetComponentInChildren<Text>().text = "현재 매력 : " + GameManager.charm;        
    }
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
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                if (child2.activeSelf == true)
                    boolean = true;
            }
        }
        if (boolean == false)
            button.GetComponent<Button>().interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        CharmItems[0, 0] = CharmItems[0, 1] = CharmItems[0, 2] = 1;
        /*string mybutton;
        if (GameManager.youtubaButton != null)
        {
            Debug.Log("현재 버튼 정보 있음");
            mybutton = GameManager.youtubaButton;
            Debug.Log("mybutton" + mybutton);
            if (mybutton.Equals("bronze") || mybutton == null || mybutton == "")
            {
                maxCharm = maxEdit = 100;
            }
            else if (mybutton.Equals("silver"))
            {
                maxCharm = maxEdit = 300;
            }
            else if (mybutton.Equals("gold"))
            {
                maxCharm = maxEdit = 500;
            }
            else if (mybutton.Equals("diamond"))
            {
                maxCharm = maxEdit = 700;
            }
            else if (mybutton.Equals("ruby"))
            {
                maxCharm = maxEdit = 1000;
            }
        }
        else
        {
            //Debug.Log("현재 버튼 null");
            maxCharm = maxEdit = 100;
        }*/
        /*GameObject itemCollection = GameObject.Find("아이템");
        GameObject child, child2, go;
        int charming = 0;
        string str;
        string[] spstring;

        for (int i = 0; i < itemCollection.transform.childCount; i++)   //캐릭터 아이템 착용 초기화
        {
            child = itemCollection.transform.GetChild(i).gameObject;            
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                if (Index[i] == j)
                {
                    if((i == 1 || i == 2) && j == 0)
                        child2.SetActive(false);
                    else
                    {
                        child2.SetActive(true);
                        str = child2.name;
                        spstring = str.Split('_');
                        str = spstring[0];
                        go = GameObject.Find(str);
                        str = go.GetComponentInChildren<Text>().text;
                        spstring = str.Split('+');
                        charming += int.Parse(spstring[1]);
                    }                        
                }
                else
                {
                    child2.SetActive(false);
                }                
            }
        }
        GameManager.charm = charming;
        GameObject go2;
        go2 = GameObject.Find("MyGMCharmStat");
        go2.GetComponentInChildren<Text>().text = "현재 매력 : " + GameManager.charm;*/
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < HI.transform.childCount; i++)   //건강item개수 업데이트
        {
            child = HI.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                Count = child2.transform.GetChild(1).gameObject;
                str = HealthItems[i, j].ToString();
                Count.GetComponentInChildren<Text>().text = "X" + str;
                if (HealthItems[i, j] < 1)
                {
                    child2.GetComponent<Button>().interactable = false;
                }
            }
        }

        for (int i = 0; i < CI.transform.childCount; i++)   //매력item 개수에 따라 버튼 활성화
        {
            child = CI.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                if (CharmItems[i, j] < 1)
                {
                    child2.GetComponent<Button>().interactable = false;
                }
                else
                    child2.GetComponent<Button>().interactable = true;

            }
        }

        for (int i = 0; i < EI.transform.childCount; i++)   //편집item개수 업데이트
        {
            child = EI.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                Count = child2.transform.GetChild(4).gameObject;
                str = EditItems[i, j].ToString();
                Count.GetComponentInChildren<Text>().text = "X" + str;
                if (EditItems[i, j] < 1)
                {
                    child2.GetComponent<Button>().interactable = false;
                }

            }
        }


        /*go = GameObject.Find("MyGMHealthStat");
        go.GetComponentInChildren<Text>().text = "현재 GMCHealth : " + GameManager.health;*/

    }

}
