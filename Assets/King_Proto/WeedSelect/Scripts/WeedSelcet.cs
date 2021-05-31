using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSelcet : MonoBehaviour
{
    Transform weed;
    LineRenderer lr;
    public Transform[] wd;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        DrawGuideLine();
        WeedCatch();
        //WeedDrop();
    }

    void DrawGuideLine()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
        //else
        //{
        //    lr.SetPosition(0, transform.position);
        //    lr.SetPosition(1, transform.position + transform.forward * 1);
        //}
    }

    void WeedCatch()
    {
        if(Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.SphereCast(ray, 0.5f , out hit, 10f, LayerMask.NameToLayer("Weed")))
            {
                weed = hit.transform;
                hit.transform.SetParent(transform);
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                rb.isKinematic = true;
            }
        }
    }

    void WeedDrop()
    {
        if (weed = null) return;

        if(Input.GetMouseButtonUp(0) || OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            weed.SetParent(null);
            weed.GetComponent<Rigidbody>().isKinematic = false;
            weed = null;

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    print("»Ì¾Ò½À´Ï´Ù");
    //    Destroy(gameObject);
    //    print("ÀâÃÊ ÆÄ±«");

    //    //if (other.tag == "Weed")
    //    //{
    //    //    Rigidbody rb = weed.GetComponent<Rigidbody>();
    //    //    rb.useGravity = true;
    //    //}

    //    //Ray ray = new Ray(transform.position, transform.forward);
    //    //RaycastHit hit;

    //    //if (Physics.Raycast(ray, out hit))
    //    //{
    //    //    for (int i = 0; i < wd.Length; i++)
    //    //    {
    //    //        if (hit.collider.gameObject == wd[i])
    //    //        {
    //    //            Rigidbody rb = wd[i].GetComponent<Rigidbody>();
    //    //            rb.useGravity = true;
    //    //        }
    //    //    }
    //    //}
    //}
}
