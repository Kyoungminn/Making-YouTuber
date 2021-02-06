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
        GameManager.game_time += Time.deltaTime;
         //Debug.Log("현재시간: " + GameManager.game_time);
    }
}
