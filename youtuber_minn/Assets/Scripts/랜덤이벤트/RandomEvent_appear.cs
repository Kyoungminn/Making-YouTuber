using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent_appear : MonoBehaviour
{
    private IEnumerator coroutine;
    public List<GameObject> QuestionAppear = new List<GameObject>();

    public static int Time_before = 0;

    public void Appear()
    {
        SoundManager._soundInstance.PopupAudio();
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.game_time);
        if ((int)(GameManager.game_time - (float)Time_before) >= 7)
        {
            int rand = Random.Range(0, 10);

            switch (rand) { case 0:case 1: case 2: case 3: case 4: case 5: case 6: Appear(); break;
                default: break;
            }
            
            Time_before = (int)GameManager.game_time;
            Debug.Log(Time_before);
        }
    }
}
