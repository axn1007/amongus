using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : MonoBehaviour
{
    public GameObject[] vent;
    public GameObject player;

    void Start()
    {
        
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
        Vent.instance.energyUI.SetActive(false);
    }

    public void OnClickFirstEnergy()
    {
        print("Go to FirstRoom");
        EnergyMission.instance.energyBool[1] = true;
        Vent.instance.energyUI.SetActive(false);
    }

    public void OnClickSecondEnergy()
    {
        print("Go to SecondRoom");
        EnergyMission.instance.energyBool[2] = true;
        Vent.instance.energyUI.SetActive(false);
    }

    public void OnClickThirdEnergy()
    {
        print("Go to ThirdRoom");
        EnergyMission.instance.energyBool[3] = true;
        Vent.instance.energyUI.SetActive(false);
    }

    public void OnClickForthEnergy()
    {
        print("Go to ForthRoom");
        EnergyMission.instance.energyBool[4] = true;
        Vent.instance.energyUI.SetActive(false);
    }
}
