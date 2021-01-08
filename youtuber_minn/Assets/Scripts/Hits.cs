using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hits : MonoBehaviour
{
    public int hits;
    public int subscriber;
    private float hits_P;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 100);
        if (rand <= 80)
        {
            hits_P = Random.Range(0.1f, 1.0f);
        }
        else
        {
            hits_P = Random.Range(1.0f, 5.0f);
        }
        Debug.Log(hits_P);
        hits = (int)((float)subscriber * hits_P);
        Debug.Log(hits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
