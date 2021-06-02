using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCount : MonoBehaviour
{
    public int count;

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
            print("Mission Crear!!!!!!!!!");
        }
    }
}
