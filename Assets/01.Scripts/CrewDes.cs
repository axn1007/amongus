using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewDes : MonoBehaviour
{
    float currTime;

    void Start()
    {
        
    }

    void Update()
    {
        //currTime += Time.deltaTime;

        //if (currTime > 6.0f)
        //{
        //    Destroy(gameObject);
        //}
        //currTime = 0;

        Destroy(gameObject, 6.0f);
    }
}
