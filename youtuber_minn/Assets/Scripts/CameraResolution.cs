using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{

    private void Start()
    {
       // Screen.SetResolution(Screen.width, Screen.width * 9 / 16, true);
       float fScaleHeight = ((float)Screen.height / (float)Screen.width) / ((float)16 / (float)9);

        Vector3 vecButtonPos = GetComponent<RectTransform>().localPosition;
        vecButtonPos.y = vecButtonPos.y * fScaleHeight;
        GetComponent<RectTransform>().localPosition = new Vector3(vecButtonPos.x, vecButtonPos.y, vecButtonPos.z);
    }
}
