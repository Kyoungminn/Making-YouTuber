using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyThis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

    public void OnMoneyButtonClick()
    {
        
        GameManager.money += 5;
        Debug.Log(GameManager.money);
        gameObject.SetActive(false);
    }
}
