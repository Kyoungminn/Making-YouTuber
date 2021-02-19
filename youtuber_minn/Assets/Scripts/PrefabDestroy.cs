using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClickPrefab()
    {
        SoundManager._soundInstance.OnButtonAudio();
        Destroy(gameObject);
    }
}
