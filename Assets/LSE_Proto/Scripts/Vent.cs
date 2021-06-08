using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vent : MonoBehaviour
{
    public GameObject ventUI;

    public static Vent instance;
    public bool sliderBool;

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

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "vent")
        {
            print("this is vent!");

            if (Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                ventUI.SetActive(true);
            }
        }

        if (other.transform.tag == "lever")
        {
            print("this is lever!");

            if (Player.instance.mission[1] != true) return;

            if (Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                MissionManager.instance.missionUI[0].SetActive(true);
                sliderBool = true;
            }
        }

        if (other.transform.tag == "energy")
        {
            print("this is energy");

            if (Player.instance.mission[2] != true) return;
            if (MissionManager.instance.energyCount == 1) return;

            if(Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                MissionManager.instance.missionUI[1].SetActive(true);
            }
        }

        if(other.transform.tag == "puzzle")
        {
            print("this is puzzle");

            if (Player.instance.mission[7] != true) return;

            if (Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                MissionManager.instance.missionUI[2].SetActive(true);
            }
        }
    }
}
