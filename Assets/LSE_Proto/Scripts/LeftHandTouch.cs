using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHandTouch : MonoBehaviour
{
    LineRenderer lr;
    Transform catchedObj;
    public float throwPower = 3;
    public float pressTime = 5.0f;
    float curTime;

    void Start()
    {
        lr = GetComponent<LineRenderer>();

    }

    void Update()
    {
        //DrawGuideLine();
        ChangeStatus();
        CatchObj();
        DropObj();
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

    void ChangeStatus()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.1f, out hit, 10f))
            {
                if (hit.transform.tag != "energy") return;

                Material mt = hit.transform.GetComponent<MeshRenderer>().material;
                mt.color = Color.red;
                MissionManager.instance.EnergyMission(1);
            }
        }
    }

    void CatchObj()
    {
        if(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.SphereCast(ray, 0.5f, out hit, 100))
            {
                if (hit.transform.tag != "Bottle") return;

                catchedObj = hit.transform;
                hit.transform.SetParent(transform);
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                hit.transform.position = transform.position;

            }
        }
    }

    void DropObj()
    {
        if (catchedObj == null) return;

        if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            catchedObj.SetParent(null);
            catchedObj.GetComponent<Rigidbody>().isKinematic = false;

            ThrowObj();
                
            catchedObj = null;
        }
        
    }

    void ThrowObj()
    {
        Rigidbody rb = catchedObj.GetComponent<Rigidbody>();
        rb.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * throwPower;
        rb.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
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
                if (hit.transform.tag != "button") return;

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
