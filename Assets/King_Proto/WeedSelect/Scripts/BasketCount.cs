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
        if (other.transform.tag != "Weed") return;

        count++;
        print("���ʰ� �����ϴ�");
        //other.transform.GetComponent<CapsuleCollider>().enabled = false;

        if(count == 8)
        {
            if (myPlayer.mission[9] != true) return;
            print("Mission Crear!!!!!!!!!");
            myPlayer.myScore += 1;
        }
    }
}
