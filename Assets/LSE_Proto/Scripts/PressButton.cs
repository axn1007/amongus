using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;

    public float pressTime = 5.0f;
    float curTime;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                curTime += Time.deltaTime;
                string objectName = hit.collider.gameObject.name;

                if (curTime > pressTime)
                {
                    print(objectName + " Mission Complete!");
                    MissionManager.instance.ButtonMission(1);
                    curTime = 0;
                }        
            }
        }
    }
}
