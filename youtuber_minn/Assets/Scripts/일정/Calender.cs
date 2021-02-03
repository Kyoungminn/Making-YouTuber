using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calender : MonoBehaviour
{
    public GameObject calenderPrefab;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cal = Instantiate(calenderPrefab) as GameObject;
        cal.transform.SetParent(canvas.transform);
        cal.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        cal.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
