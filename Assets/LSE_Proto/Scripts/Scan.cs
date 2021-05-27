using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public float scanTime = 5.0f;
    float curTime;

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            //print("Hello Player!");
            
            curTime += Time.deltaTime;

            if(curTime > scanTime)
            {
                print("Misson Complete!");
                MissionManager.instance.ScanMission(1);
                curTime = 0;
            }
        }

        if(other.transform.tag == "Bottle")
        {
            curTime += Time.deltaTime;

            if(curTime > scanTime)
            {
                print("Mission Complete!");
                MissionManager.instance.BottleMission(1);
                curTime = 0;
            }
        }
    }
}