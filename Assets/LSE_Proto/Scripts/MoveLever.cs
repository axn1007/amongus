using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLever : MonoBehaviour
{
    public Slider slider;
    Player myPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        if(Vent.instance != null)
        {
            if (Vent.instance.sliderBool && slider.value == 100)
            {
                if (myPlayer.mission[1] != true) return;

                print("LeverMission Complete!");
                Vent.instance.sliderBool = false;
                myPlayer.myScore += 1;
            }

            if (!Vent.instance.sliderBool)
            {
                //MissionManager.instance.missionUI[0].SetActive(false);
                slider.value = 0;
            }
        }
    }
}
