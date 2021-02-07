using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public GameObject itemCollection, itemCollection1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject child, child2, child3, child4;
        for (int i = 0; i < itemCollection.transform.childCount; i++)   //캐릭터 아이템 착용 초기화
        {
            child = itemCollection.transform.GetChild(i).gameObject;
            child3 = itemCollection1.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {
                child2 = child.transform.GetChild(j).gameObject;
                child4 = child3.transform.GetChild(j).gameObject;
                if (ItemLocker.Index[i] == j)
                {                   
                    child2.SetActive(true);
                    child4.SetActive(true);
                }
                else
                {
                    child2.SetActive(false);
                    child4.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
