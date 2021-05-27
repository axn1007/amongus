using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{ 
    Transform catchedObj;

    void Start()
    {
        
    }

    void Update()
    {
        Catch();
        Drop();
    }

    void Catch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.1f, out hit, 1f))
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

        if (Input.GetMouseButtonUp(0))
        {
            catchedObj.SetParent(null);
            catchedObj.GetComponent<Rigidbody>().isKinematic = false;
            catchedObj = null;
        }
    }
}
