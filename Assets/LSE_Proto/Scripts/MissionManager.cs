using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class MissionManager : MonoBehaviourPun
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
        if (photonView.IsMine == false) return;

        scanCount += count;

        if (scanCount == 4)
        {
            print("ScanMission Complete");
            ManagerMaster(1);
        }
    }

    public void LeverMission(int count)
    {
        if (!photonView.IsMine && Player.instance.mission[1] != true) return;

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
        if (!photonView.IsMine && Player.instance.mission[2] != true) return;

        energyCount += count;

        if(energyCount == 1)
        {
            print("EnergyMission Complete");
            ManagerMaster(1);
            clearUI[1].SetActive(true);
        }
    }
    public void BottleMission(int count)
    {
        if (!photonView.IsMine && Player.instance.mission[3] != true) return;

        bottleCount += count;

        if (bottleCount == 1)
        {
            print("ChangeBottleMission Complete");
            ManagerMaster(1);
        }
    }

    public void ButtonMission(int count)
    {
        if (!photonView.IsMine && Player.instance.mission[4] != true) return;

        btnCount += count;

        if (btnCount == 2)
        {
            print("PressButtonMission Complete");
            ManagerMaster(1);
        }
    }

    public void FireMission(int count)
    {
        if (!photonView.IsMine && Player.instance.mission[5] != true) return;

        fireCount += count;

        if(fireCount == 1)
        {
            print("FireMission Complete");
            ManagerMaster(1);
        }
    }
}
