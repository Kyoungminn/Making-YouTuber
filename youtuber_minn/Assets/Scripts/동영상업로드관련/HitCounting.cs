using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCounting : MonoBehaviour
{
    public static HitCounting _hitCounting;
    public float current;
    public float offset, _hit;
    public int _id;

    public static GameObject HitCount;

    void Awake()
    {
        _hitCounting = this;
        HitCount = GameObject.Find("HitCountingScript");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("hitCounting");
        if (objs.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void BringHitId(float hit, int id)
    {
        _hit = hit;
        _id = id;
        StartCoroutine(CountHit(_hit, _id));
    }

    public IEnumerator CountHit(float hit, int id)
    {
        current = 0.0f;
        float duration = 60.0f; //카운팅에 걸리는 시간
        offset = hit / duration;

        while (current < hit)
        {
            current += offset * Time.deltaTime;
            yield return null;
        }

        current =hit;

        yield return null;

        VideoInfomation.hitChk = false;

        //동영상 수익 게임머니에 저장
        GameManager.money += Upload_sceneManager.uploadPayoffs[id];

        Debug.Log("조회수처리정보:" + VideoInfomation.hitChk);

        Destroy(gameObject);

    }
}
