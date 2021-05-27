using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    LineRenderer lr;

    public float pressTime = 5.0f;
    float curTime;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        DrawGuideLine();
        PressButtons();
    }

    void DrawGuideLine()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }

        else
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + transform.forward * 1);
        }
    }

    void PressButtons()
    {
        if (Input.GetMouseButton(0) || OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            //Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                curTime += Time.deltaTime;
                string objectName = hit.collider.gameObject.name;

                if (curTime > pressTime)
                {
                    print(objectName + " Mission Complete!");
                    MissionManager.instance.ButtonMission(1);
                    curTime = 0;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }


}
