using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyApear : MonoBehaviour
{
    public GameObject prefabMoney; //돈 프리팹
    public GameObject moneyParent; //캔버스

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ApearMoney());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ApearMoney()
    {
        while(true)
        {
            //int numRand = Random.Range(1, 3);
            float timeRand = Random.Range(4.5f, 5.0f);

            //for (int i = 0; i < numRand; i++)
            //{
                //Debug.Log("생성!");
                Vector3 creatingPoint = new Vector3(Random.Range(-480f, 480f), Random.Range(-790f, 440f), 0f);
                GameObject child = Instantiate(prefabMoney) as GameObject;
                child.transform.SetParent(moneyParent.transform);
                child.transform.localPosition = creatingPoint;
                child.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            //}

            yield return new WaitForSeconds(timeRand);
        }
    }
}
