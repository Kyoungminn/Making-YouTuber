﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    public List<GameObject> Result = new List<GameObject>();
    public List<GameObject> Result2 = new List<GameObject>();
    public List<GameObject> Result3 = new List<GameObject>();
    public List<GameObject> Result4 = new List<GameObject>();
    public List<GameObject> Result5 = new List<GameObject>();
    public List<GameObject> Result6 = new List<GameObject>();
    //public List<GameObject> Result7 = new List<GameObject>();
    public List<GameObject> Result8 = new List<GameObject>();
    public List<GameObject> Result9 = new List<GameObject>();
    public List<GameObject> Result10 = new List<GameObject>();
    public List<GameObject> Result11 = new List<GameObject>();
    public List<GameObject> Result12 = new List<GameObject>();
    public List<GameObject> Result13 = new List<GameObject>();
    public List<GameObject> Result14 = new List<GameObject>();
    public List<GameObject> Result15 = new List<GameObject>();
    public List<GameObject> Result16 = new List<GameObject>();
    public List<GameObject> Result17 = new List<GameObject>();
    public List<GameObject> Result18 = new List<GameObject>();
    public List<GameObject> Result19 = new List<GameObject>();
    public List<GameObject> Result20 = new List<GameObject>();

    public List<GameObject> QuestionAppear = new List<GameObject>(); //랜덤이벤트캔버스저장

    public void Question1()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.subscriber += (int)(GameManager.subscriber * 0.03f);
            Debug.Log(GameManager.subscriber);
            Result[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.03f);
            Debug.Log(GameManager.subscriber);
            Result[1].SetActive(true);
        }
    }
    public void Question2()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.subscriber += 30;
            Debug.Log(GameManager.subscriber);
            Result2[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.03f);
            Debug.Log(GameManager.subscriber);
            Result2[1].SetActive(true);
        }
    }

    public void Question3()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.edit += (int)(GameManager.edit*0.1f);
            Debug.Log(GameManager.edit);
            Result3[0].SetActive(true);
        }
        else
        {
            GameManager.health -= 10;
            Debug.Log(GameManager.health);
            Result3[1].SetActive(true);
        }
    }
    public void Question4()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.subscriber += (int)(GameManager.subscriber * 0.01f);
            Debug.Log(GameManager.subscriber);
            Result4[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber*0.05f);
            Debug.Log(GameManager.subscriber);
            Result4[1].SetActive(true);
        }
    }

    public void Question5()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.health += 20;
            Debug.Log(GameManager.health);
            Result5[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.1f);
            Debug.Log(GameManager.subscriber);
            Result5[1].SetActive(true);
        }
    }

    public void Question6()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.health += 20;
            Debug.Log(GameManager.health);
            Result6[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.1f);
            Debug.Log(GameManager.subscriber);
            Result6[1].SetActive(true);
        }
    }
    public void Question7()
    {
        SoundManager._soundInstance.OnButtonAudio();
        GameManager.money -= 50000;
        GameManager.subscriber += (int)(GameManager.subscriber * 0.05f);
        Debug.Log(GameManager.money);
        Debug.Log(GameManager.subscriber);
    }
    public void Question8()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.charm += (int)(GameManager.charm * 0.05f);
            Debug.Log(GameManager.charm);
            Result8[0].SetActive(true);
        }
        else
        {
            GameManager.charm -= (int)(GameManager.charm * 0.03f);
            Debug.Log(GameManager.charm);
            Result8[1].SetActive(true);
        }
    }
    public void Question9()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.money -=3000;
            GameManager.health +=30;
            Debug.Log(GameManager.money);
            Debug.Log(GameManager.health);
            Result9[0].SetActive(true);
        }
        else
        {
            GameManager.money -= 3000;
            Debug.Log(GameManager.money);
            Result9[1].SetActive(true);
        }
    }
    public void Question10()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.money -= 30000;
            Debug.Log(GameManager.money);
            Result10[0].SetActive(true);
        }
        else
        {
            GameManager.money -= 30000;
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.03f);
            Debug.Log(GameManager.money);
            Debug.Log(GameManager.subscriber);
            Result10[1].SetActive(true);
        }
    }
    public void Question11()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.subscriber += (int)(GameManager.subscriber * 0.05f);
            Debug.Log(GameManager.subscriber);
            Result11[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.05f);
            Debug.Log(GameManager.subscriber);
            Result11[1].SetActive(true);
        }
    }
    public void Question12()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.charm += (int)(GameManager.charm * 0.1f);
            Debug.Log(GameManager.charm);
            Result12[0].SetActive(true);
        }
        else
        {
            GameManager.health -= 10;
            Debug.Log(GameManager.health);
            Result12[1].SetActive(true);
        }
    }
    public void Question13()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.money += 50000;
            Debug.Log(GameManager.money);
            Result13[0].SetActive(true);
        }
        else
        {
            GameManager.money -= 50000;
            Debug.Log(GameManager.money);
            Result13[1].SetActive(true);
        }
    }
    public void Question14()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.charm += (int)(GameManager.charm * 0.2f);
            Debug.Log(GameManager.charm);
            Result14[0].SetActive(true);
        }
        else
        {
            GameManager.health -=15;
            Debug.Log(GameManager.health);
            Result14[1].SetActive(true);
        }
    }
    public void Question15()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.subscriber += (int)(GameManager.subscriber / 100);
            Debug.Log(GameManager.subscriber);
            Result15[0].SetActive(true);
        }
        else
        {
            GameManager.health -= 10;
            Debug.Log(GameManager.health);
            Result15[1].SetActive(true);
        }
    }
    public void Question16()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.money += 30000;
            GameManager.charm += (int)(GameManager.charm * 0.05f);
            Debug.Log(GameManager.money);
            Debug.Log(GameManager.charm);
            Result16[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.05f);
            Debug.Log(GameManager.subscriber);
            Result16[1].SetActive(true);
        }
    }
    public void Question17()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.money += 50000;
            Debug.Log(GameManager.money);
            Result17[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.03f);
            Debug.Log(GameManager.subscriber);
            Result17[1].SetActive(true);
        }
    }
    public void Question18()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.charm += (int)(GameManager.charm * 0.2f);
            Debug.Log(GameManager.charm);
            Result18[0].SetActive(true);
        }
        else
        {
            GameManager.charm -= (int)(GameManager.charm * 0.1f);
            Debug.Log(GameManager.charm);
            Result18[1].SetActive(true);
        }
    }
    public void Question19()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.edit += (int)(GameManager.edit * 0.2f);
            Debug.Log(GameManager.edit);
            Result19[0].SetActive(true);
        }
        else
        {
            GameManager.subscriber -= (int)(GameManager.subscriber * 0.1f);
            Debug.Log(GameManager.subscriber);
            Result19[1].SetActive(true);
        }
    }
    public void Question20()
    {
        SoundManager._soundInstance.OnButtonAudio();
        int rand;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameManager.money += 30000;
            GameManager.charm += (int)(GameManager.charm * 0.1f);
            Debug.Log(GameManager.money);
            Debug.Log(GameManager.charm);
            Result20[0].SetActive(true);
        }
        else
        {
            GameManager.charm -= (int)(GameManager.charm * 0.1f);
            Debug.Log(GameManager.charm);
            Result20[1].SetActive(true);
        }
    }

    public void OnButtonPlay()
    {
        SoundManager._soundInstance.OnButtonAudio();
    }

    // Start is called before the first frame update
    void Start()
    {
        int rand;
        rand = Random.Range(0, 20);
        switch (rand)
        {
            case 0: QuestionAppear[0].SetActive(true); break;
            case 1: QuestionAppear[1].SetActive(true); break;
            case 2: QuestionAppear[2].SetActive(true); break;
            case 3: QuestionAppear[3].SetActive(true); break;
            case 4: QuestionAppear[4].SetActive(true); break;
            case 5: QuestionAppear[5].SetActive(true); break;
            case 6: QuestionAppear[6].SetActive(true); break;
            case 7: QuestionAppear[7].SetActive(true); break;
            case 8: QuestionAppear[8].SetActive(true); break;
            case 9: QuestionAppear[9].SetActive(true); break;
            case 10: QuestionAppear[10].SetActive(true); break;
            case 11: QuestionAppear[11].SetActive(true); break;
            case 12: QuestionAppear[12].SetActive(true); break;
            case 13: QuestionAppear[13].SetActive(true); break;
            case 14: QuestionAppear[14].SetActive(true); break;
            case 15: QuestionAppear[15].SetActive(true); break;
            case 16: QuestionAppear[16].SetActive(true); break;
            case 17: QuestionAppear[17].SetActive(true); break;
            case 18: QuestionAppear[18].SetActive(true); break;
            case 19: QuestionAppear[19].SetActive(true); break;
        }
    }

    // Update is called once per frame
    void Update(){
    }
}
