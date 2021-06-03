using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftHandTouch : MonoBehaviour
{
    public float throwPower = 3;
    public float pressTime = 5.0f;
    float curTime;
    
    public GameObject pos;
    public GameObject doc;
    public Transform middlePos;
    public Transform startPos;
    public float speed = 1f;
    public int count;

    void Start()
    {

    }

    void Update()
    {
        ChangeStatus();
        PressButtons();
        DestroyTrash();
    }

    void ChangeStatus()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.1f, out hit, 1))
            {
                if (hit.transform.tag != "energy") return;

                Material mt = hit.transform.GetComponent<MeshRenderer>().material;
                mt.color = Color.red;
                MissionManager.instance.EnergyMission(1);
            }
        }
    }

    void PressButtons()
    {
        if (Input.GetMouseButton(0) || OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "button")
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

            if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("Btn")))
            {
                curTime += Time.deltaTime;
                doc.transform.position = GetPoint(startPos.position, middlePos.position, pos.transform.position, curTime / 3);
            }
        }
    }

    Vector3 GetPoint(Vector3 s, Vector3 m, Vector3 e, float ratio)
    {
        Vector3 p1 = Vector3.Lerp(s, m, ratio);
        Vector3 p2 = Vector3.Lerp(m, e, ratio);
        Vector3 p3 = Vector3.Lerp(p1, p2, ratio);
        return p3;
    }

    void DestroyTrash()
    {
        if (Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.1f, out hit, 1))
            {

                if (hit.transform.tag != "trash") return;

                if (hit.transform != null)
                {
                    Destroy(hit.collider.gameObject);
                    print("우주 쓰레기 제거!");
                    count++;
                    print("우주 쓰레기가 담겼어요");
                }
            }
            StCount();
        }
    }

    void StCount()
    {
        if (count == 6)
        {
            print("Mission Clear!!!!!");
        }
    }
}
