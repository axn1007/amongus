using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    int masterCount;

    int scanCount;
    int btnCount;
    int bottleCount;
    int leverCount;
    public int energyCount;
    int fireCount;
    public GameObject [] clearUI;

    public GameObject[] missionUI;

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

        if(scanCount == 4)
        {
            print("ScanMission Complete");
            ManagerMaster(1);
        }
    }

    public void ButtonMission(int count)
    {
        btnCount += count;

        if(btnCount == 2)
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

    public void LeverMission(int count)
    {
        leverCount += count;

        if(leverCount == 1)
        {
            print("LeverMission Complete");
            ManagerMaster(1);
            clearUI[0].SetActive(true);
        }
    }

    public void EnergyMission(int count)
    {
        energyCount += count;

        if(energyCount == 1)
        {
            print("EnergyMission Complete");
            ManagerMaster(1);
            clearUI[1].SetActive(true);
        }
    }

    public void FireMission(int count)
    {
        fireCount += count;

        if(fireCount == 1)
        {
            print("FireMission Complete");
            ManagerMaster(1);
        }
    }
}
