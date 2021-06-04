using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLever : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        
    }

    void Update()
    {
        if(Vent.instance != null)
        {
            if (Vent.instance.sliderBool && slider.value == 100)
            {
                print("LeverMission Complete!");
                Vent.instance.sliderBool = false;
                MissionManager.instance.LeverMission(1);
            }

            if (!Vent.instance.sliderBool) MissionManager.instance.missionUI[0].SetActive(false);
        }
    }
}
