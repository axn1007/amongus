using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCount : MonoBehaviour
{
    public int count;
    public Player myPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        count++;
        print("잡초가 담겼습니다");

        if(count == 8)
        {
            if (myPlayer.mission[9] != true) return;
            print("Mission Crear!!!!!!!!!");
            myPlayer.myScore += 1;
        }
    }
}
