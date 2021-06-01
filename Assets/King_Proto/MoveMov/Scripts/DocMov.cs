using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocMov : MonoBehaviour
{
    //public GameObject doc;
    //public GameObject pos;
    //LineRenderer lr;
    //public Transform middlePos;
    //public Transform startPos;
    //float currTime;
    //public float speed = 1f;

    void Start()
    {
      //  lr = middlePos.GetComponent<LineRenderer>();
    }

    void Update()
    {
        /*
        //lr.positionCount = 0;
        //for (int i = 0; i < 20; i++)
        //{
        //    lr.positionCount++;
        //    lr.SetPosition(lr.positionCount - 1, GetPoint(startPos.position, middlePos.position, pos.transform.position, i / 20.0f));
        //}
        
        if (Input.GetMouseButton(0))
        {

            print("클릭");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("Btn")))
            {
                print("레이를 쏨");

                currTime += Time.deltaTime;
                transform.position = GetPoint(startPos.position, middlePos.position, pos.transform.position, currTime / 3);

                //원점에서만 포물선으로 움직임
                //transform.position = Vector3.Slerp(transform.position, poss.transform.position, speed);
                //transform.position = Vector3.Slerp(transform.position, pos.transform.position, speed);
            }
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Pos")
        {
            print("Mission Clear!!!!!!!");
        }
    }
/*
    Vector3 GetPoint(Vector3 s, Vector3 m, Vector3 e, float ratio)
    {
        Vector3 p1 = Vector3.Lerp(s, m, ratio);
        Vector3 p2 = Vector3.Lerp(m, e, ratio);
        Vector3 p3 = Vector3.Lerp(p1, p2, ratio);
        return p3;
    }
  */  
}
