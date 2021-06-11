using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBtn : MonoBehaviour
{
    float curTime;
    float retrunTime = 30.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == false)
        {
            curTime += Time.deltaTime;
            if(curTime > retrunTime)
            {
                gameObject.SetActive(true);
                curTime = 0;
            }
        }
    }
}
