using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vent : MonoBehaviour
{
    public GameObject ventUI;
    public static Vent instance;

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
    }
}
