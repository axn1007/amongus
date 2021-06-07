using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    public static Player instance;
    
    public bool[] mission;
    public bool imposter;
    public bool crew;

    Vector3 myFirstPos;

    public GameObject missionUI;
    public GameObject missionBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Vector3 pos = GameManager.instance.GetEmptyPos();
            photonView.RPC("RpcSetInit", RpcTarget.AllBuffered, pos);
            myFirstPos = pos;
        }

        GameManager.instance.AddPlayer(this);
    }

    void Update()
    {
        UIClick();
    }

    void UIClick()
    {
        if(Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            missionUI.SetActive(true);
            missionBar.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space) || OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            missionUI.SetActive(false);
            missionBar.SetActive(false);
        }
    }

    void CallCrew()
    {
        float v = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LHand);

        if (Input.GetKeyDown(KeyCode.Alpha5) || v > 0)
        {
            photonView.RPC("CallCrewPos", RpcTarget.All);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "emergency")
        {
            CallCrew();
        }
    }

    [PunRPC]
    void CallCrewPos()
    {
        transform.position = myFirstPos + new Vector3(0, 1.39f, 0);
    }

    [PunRPC]
    void RpcSetInit(Vector3 pos)
    {
        transform.position = pos + new Vector3(0, 1.39f, 0);
    }
}

