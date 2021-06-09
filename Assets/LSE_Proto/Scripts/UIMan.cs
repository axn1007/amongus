using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIMan : MonoBehaviourPun
{
    public GameObject[] vent;
    public GameObject player;
    
    void Start()
    {
        vent = new GameObject[]
        {
            GameObject.Find("MAP/Vent/Vent1"),
            GameObject.Find("MAP/Vent/Vent2"),
            GameObject.Find("MAP/Vent/Vent3"),
            GameObject.Find("MAP/Vent/Vent4"),
            GameObject.Find("MAP/Vent/Vent5"),
        };
    }

    void Update()
    {
        
    }

    public void OnClickVent(int idx)
    {
        photonView.RPC("MoveVentPos", RpcTarget.All, vent[idx].transform.position + new Vector3(0, 1.39f, 0));
    }

    public void OnClickVentOne()
    {
        print("MainVent");
        photonView.RPC("MoveVentPos", RpcTarget.All, vent[0].transform.position + new Vector3(0, 1.39f, 0));
    }

    public void OnClickVentTwo()
    {
        print("MainVent");
        photonView.RPC("MoveVentPos", RpcTarget.All, vent[1]);
    }

    public void OnClickVentThree()
    {
        print("MainVent");
        photonView.RPC("MoveVentPos", RpcTarget.All, vent[2]);
    }

    public void OnClickVentFour()
    {
        print("MainVent");
        photonView.RPC("MoveVentPos", RpcTarget.All, vent[3]);
    }

    public void OnClickVentFive()
    {
        print("MainVent");
        photonView.RPC("MoveVentPos", RpcTarget.All, vent[4]);
    }

    public void OnClickMainEnergy()
    {
        print("Go to MainRoom");
        EnergyMission.instance.energyBool[0] = true;
        MissionManager.instance.missionUI[1].SetActive(false);
    }

    public void OnClickFirstEnergy()
    {
        print("Go to FirstRoom");
        EnergyMission.instance.energyBool[1] = true;
        MissionManager.instance.missionUI[1].SetActive(false);
    }

    public void OnClickSecondEnergy()
    {
        print("Go to SecondRoom");
        EnergyMission.instance.energyBool[2] = true;
        MissionManager.instance.missionUI[1].SetActive(false);
    }

    public void OnClickThirdEnergy()
    {
        print("Go to ThirdRoom");
        EnergyMission.instance.energyBool[3] = true;
        MissionManager.instance.missionUI[1].SetActive(false);
    }

    public void OnClickForthEnergy()
    {
        print("Go to ForthRoom");
        EnergyMission.instance.energyBool[4] = true;
        MissionManager.instance.missionUI[1].SetActive(false);
    }
}
