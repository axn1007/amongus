using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject [] vent; 

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
            print("This is vent!");

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                transform.position = vent[0].transform.position + new Vector3(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                transform.position = vent[1].transform.position + new Vector3(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                transform.position = vent[2].transform.position + new Vector3(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                transform.position = vent[3].transform.position + new Vector3(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                transform.position = vent[4].transform.position + new Vector3(0, 1, 0);
            }

        }
    }
}
