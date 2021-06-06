using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : MonoBehaviour
{
    GameObject[] vent;
    public PlayerMove player;

    void Start()
    {
        vent = new GameObject[] { 
            GameObject.Find("Map/Vent/Vent1"),
            GameObject.Find("Map/Vent/Vent2"),
            GameObject.Find("Map/Vent/Vent3"),
            GameObject.Find("Map/Vent/Vent4"),
            GameObject.Find("Map/Vent/Vent5"),
        };
        
    }

    void Update()
    {
        
    }

    public void OnClickMainRoom()
    {
        player.transform.position = vent[0].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickFirstZone()
    {
        player.transform.position = vent[1].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickSecondZone()
    {
        print(vent[0].gameObject.name);
        player.transform.position = vent[2].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickThirdZone()
    {
        player.transform.position = vent[3].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickForthZone()
    {
        player.transform.position = vent[4].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
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
