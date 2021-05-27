using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    int masterCount;

    int scanCount;
    int btnCount;
    int bottleCount;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ManagerMaster(int count)
    {
        masterCount += count;
        print("MASTER COUNT is " + masterCount);
    }

    public void ScanMission(int count)
    {
        scanCount += count;

        if(scanCount == 5)
        {
            print("ScanMission Complete");
            ManagerMaster(1);
        }
    }

    public void ButtonMission(int count)
    {
        btnCount += count;

        if(btnCount == 3)
        {
            print("PressButtonMission Complete");
            ManagerMaster(1);
        }
    }

    public void BottleMission(int count)
    {
        bottleCount += count;

        if(bottleCount == 1)
        {
            print("ChangeBottleMission Complete");
            ManagerMaster(1);
        }
    }

}
