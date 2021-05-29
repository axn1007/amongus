using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandTouch : MonoBehaviour
{
    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();

    }

    void Update()
    {
        DrawGuideLine();
        ChangeStatus();
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

    void ChangeStatus()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.1f, out hit, 10f))
            {
                Material mt = hit.transform.GetComponent<MeshRenderer>().material;
                mt.color = Color.red;
                MissionManager.instance.EnergyMission(1);
            }
        }
    }
}
