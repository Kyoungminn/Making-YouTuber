using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.game_time += (Time.deltaTime/60.0f);
        GameManager.game_day += (Time.deltaTime / 60.0f);

        int month = GameManager.game_month;
        float day = GameManager.game_day;
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if (day >= 32.0f)
            {
                GameManager.game_day = 1.0f;
                GameManager.game_month++;
                if (GameManager.game_month > 12) GameManager.game_month = 1; 
            }
        }

        else if (month == 2)
        {
            if (day >= 29.0f)
            {
                GameManager.game_day = 1.0f;
                GameManager.game_month++;
            }
        }

        else
        {
            if (day >= 31.0f)
            {
                GameManager.game_day = 1.0f;
                GameManager.game_month++;
            }
        }

        //Debug.Log("현재시간: " + (int)GameManager.game_time);
        Debug.Log(GameManager.game_month + "월" + (int)GameManager.game_day + "일");
    }
}
