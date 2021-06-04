using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMission : MonoBehaviour
{
    public static EnergyMission instance;
    public GameObject [] energyButton;
    public bool [] energyBool;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for(int i = 0; i< 5; i++)
        {
            energyButton = new GameObject[] {
            GameObject.Find("Mission/EnergyMission/Energy" + i) };
        }

        /*
        energyButton = new GameObject[] {
            GameObject.Find("Mission/EnergyMission/Energy1"),
            GameObject.Find("Mission/EnergyMission/Energy2"),
            GameObject.Find("Mission/EnergyMission/Energy3"),
            GameObject.Find("Mission/EnergyMission/Energy4"),
            GameObject.Find("Mission/EnergyMission/Energy5") };
        */

    }

    void Update()
    {
        for(int i = 0; i < energyBool.Length; i++)
        {
            if(energyBool[i] != false)
            {
                energyButton[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
