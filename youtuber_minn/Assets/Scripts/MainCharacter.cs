using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public GameObject itemCollection;
    // Start is called before the first frame update
    void Start()
    {
        GameObject child, child2;
        for (int i = 0; i < itemCollection.transform.childCount; i++)   //캐릭터 아이템 착용 초기화
        {
            child = itemCollection.transform.GetChild(i).gameObject;
            for (int j = 0; j < child.transform.childCount; j++)
            {                
                if (ItemLocker.Index[i] == j)
                {
                    child2 = child.transform.GetChild(j).gameObject;
                    child2.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
