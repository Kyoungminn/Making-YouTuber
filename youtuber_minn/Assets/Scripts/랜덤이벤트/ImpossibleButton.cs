using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpossibleButton : MonoBehaviour
{
    public List<GameObject> Buttons = new List<GameObject>();
    public List<GameObject> Button7 = new List<GameObject>();
    public List<GameObject> Button9 = new List<GameObject>();
    public List<GameObject> Button10 = new List<GameObject>();
    public List<GameObject> Button13 = new List<GameObject>();
    public void Q7_Impossible()
    {
        if (GameManager.money > 50000)
        {
            Button7[0].SetActive(true);
        }
        else Button7[1].SetActive(true);
    }
    public void Q9_Impossible()
    {
        if (GameManager.money >3000)
        {
            Button9[0].SetActive(true);
        }
        else Button9[1].SetActive(true);
    }
    public void Q10_Impossible()
    {
        if (GameManager.money > 30000)
        {
            Button10[0].SetActive(true);
        }
        else Button10[1].SetActive(true);
    }
    public void Q13_Impossible()
    {
        if (GameManager.money > 50000)
        {
            Button13[0].SetActive(true);
        }
        else Button13[1].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Buttons[0].activeSelf == true)
        {
            Q7_Impossible();
        }
        else if (Buttons[1].activeSelf == true)
        {
            Q9_Impossible();
        }
        else if (Buttons[2].activeSelf == true)
        {
            Q10_Impossible();
        }
        else if (Buttons[3].activeSelf == true)
        {
            Q13_Impossible();
        }
    }
}
