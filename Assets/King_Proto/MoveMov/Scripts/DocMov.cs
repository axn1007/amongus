using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocMov : MonoBehaviour
{
    //public GameObject doc;
    public GameObject pos;
    //public GameObject docFactory;
    public float speed = 0.05f;

    void Start()
    {
        //docFactory = Instantiate(doc);

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            print("클릭");
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 10f, out hit, 100f, LayerMask.NameToLayer("Cube")))
            {
                print("레이를 쏨");
                transform.position = Vector3.Slerp(transform.position, pos.transform.position, speed);
            }
        }
    }

    
}
