using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandGrab : MonoBehaviour
{
    Transform catchedObj;
    public float throwPower = 3;
    public float pressTime = 5.0f;
    float curTime;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GrabObj();
        CatchObj();
        DropObj();
        //LocateObj();
        
    }

    void GrabObj()
    {
        float v = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        if (v > 0)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.5f, out hit, 100))
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

        float v = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        if (v == 0)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            catchedObj.SetParent(null);
            catchedObj.GetComponent<Rigidbody>().isKinematic = false;

            ThrowObj();

            catchedObj = null;
        }
    }

    void CatchObj()
    {
        float v = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        if (v > 0)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.5f, out hit, 10f))
            {
                if (hit.transform.tag != "Weed") return;

                catchedObj = hit.transform;
                hit.transform.SetParent(transform);
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = true;
            }
        }
    }
    /*
    void LocateObj()
    {
        if (catchedObj == null) return;

        float v = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        
        if (v > 0) 
        {
            catchedObj.SetParent(null);
            catchedObj.GetComponent<Rigidbody>().isKinematic = false;
            catchedObj = null;
        }
    }
    */

    void ThrowObj()
    {
        Rigidbody rb = catchedObj.GetComponent<Rigidbody>();
        rb.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * throwPower;
        rb.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
    }

}
