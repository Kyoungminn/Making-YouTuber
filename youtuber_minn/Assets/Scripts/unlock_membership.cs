using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock_membership : MonoBehaviour
{
    public GameObject lock_bronze;
    public GameObject lock_silver;
    public GameObject lock_gold;
    public GameObject lock_dia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.subscriber >= 10000 && GameManager.charm >= 100)
        {
            Destroy(lock_bronze);
            GameManager.youtubaButton = GameManager.button_name[1];
        }
        if (GameManager.subscriber >= 100000 && GameManager.charm >= 300)
        {
            Destroy(lock_silver);
            GameManager.youtubaButton = GameManager.button_name[2];
        }
        if (GameManager.subscriber >= 1000000 && GameManager.charm >= 500)
        {
            Destroy(lock_gold);
            GameManager.youtubaButton = GameManager.button_name[3];
        }
        if (GameManager.subscriber >= 10000000 && GameManager.charm >= 700)
        {
            Destroy(lock_dia);
            GameManager.youtubaButton = GameManager.button_name[4];
        }

        
    }
}
