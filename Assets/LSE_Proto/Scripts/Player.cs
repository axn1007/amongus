using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviourPun
{
    public static Player instance;
    
    public bool[] mission;
    public bool imposter;
    public bool crew;
    public int infoNum;
    int i;

    public Text countDown;
    public GameObject[] intro;

    Vector3 myFirstPos;

    public GameObject missionUI;
    public GameObject missionBar;

    public GameObject aiColor;
    public GameObject otherAiColor;

    public List<Material> colors = new List<Material>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        infoNum = photonView.OwnerActorNr;

        if (PhotonNetwork.IsMasterClient)
        {
            Vector3 pos = GameManager.instance.GetEmptyPos();
            photonView.RPC("RpcSetInit", RpcTarget.AllBuffered, pos, infoNum);
            myFirstPos = pos;
        }

        GameManager.instance.AddPlayer(this);
        /*
        if (photonView.IsMine)
        {
            GameObject go = GameObject.Find("VoteCanvas");
            go.GetComponent<OVRRaycaster>().enabled = true;
        }
        */
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
    void RpcSetInit(Vector3 pos, int infoNum)
    {
        transform.position = pos + new Vector3(0, 1.39f, 0);
        aiColor.GetComponent<SkinnedMeshRenderer>().material = colors[infoNum - 1];
        otherAiColor.GetComponent<SkinnedMeshRenderer>().material = colors[infoNum - 1];
    }

    [PunRPC]
    void MoveVentPos(GameObject vent)
    {
        transform.position = vent.transform.position + new Vector3(0, 1.39f, 0);
    }
}

