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
                if (Player.instance.mission[0] != true) return;

                print("Misson Complete!");
                MissionManager.instance.ScanMission(1);
                curTime = 0;
            }
        }

        if(other.transform.name == "Bottle2")
        {
            curTime += Time.deltaTime;

            if(curTime > scanTime)
            {
                if (Player.instance.mission[3] != true) return;

                print("Mission Complete!");
                MissionManager.instance.BottleMission(1);
                curTime = 0;
            }
        }
    }
}
