using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{ 
    Transform catchedObj;
    //LineRenderer lr;

    void Start()
    {
        //lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        //DrawGuideLine();
        Catch();
        Drop();
    }

    //void DrawGuideLine()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        lr.SetPosition(0, transform.position);
    //        lr.SetPosition(1, hit.point);
    //    }

    //    else
    //    {
    //        lr.SetPosition(0, transform.position);
    //        lr.SetPosition(1, transform.position + transform.forward * 1);
    //    }
    //}

    void Catch()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.5f, out hit, 10f))
            {
                catchedObj = hit.transform;
                hit.transform.SetParent(transform);
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                rb.isKinematic = true;
            }
        }
    }

    void Drop()
    {
        if (catchedObj == null) return;

        if (Input.GetMouseButtonUp(0) || OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            catchedObj.SetParent(null);
            catchedObj.GetComponent<Rigidbody>().isKinematic = false;
            catchedObj = null;
        }
    }
}
