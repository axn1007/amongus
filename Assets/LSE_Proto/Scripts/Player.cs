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
        //if(photonView.IsMine)
        //{
        //    GameManager.instance.myPlayer = this;
        //}
        infoNum = photonView.OwnerActorNr;

        if (PhotonNetwork.IsMasterClient)
        {
            Vector3 pos = GameManager.instance.GetEmptyPos();
            photonView.RPC("RpcSetInit", RpcTarget.AllBuffered, pos, infoNum);
            myFirstPos = pos;
        }

        GameManager.instance.AddPlayer(this);

        StartCoroutine(ImOrCrew());
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
        if(Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            missionUI.SetActive(true);
            missionBar.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) || OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            missionUI.SetActive(false);
            missionBar.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "emergency")
        {
            CallCrew();
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

    [PunRPC]
    void CallCrewPos()
    {
        transform.position = myFirstPos + new Vector3(0, 1.39f, 0);
    }

    [PunRPC]
    void RpcSetInit(Vector3 pos, int infoNum)
    {
        transform.position = pos + new Vector3(0, 1.39f, 0);
        aiColor.GetComponent<SkinnedMeshRenderer>().material = colors[infoNum];
        otherAiColor.GetComponent<SkinnedMeshRenderer>().material = colors[infoNum];
    }

    [PunRPC]
    void MoveVentPos(GameObject vent)
    {
        transform.position = vent.transform.position + new Vector3(0, 1.39f, 0);
    }

    [PunRPC]
    void SetImposter(bool isImposter)
    {
        imposter = isImposter;
        crew = !isImposter;
        if(photonView.IsMine)
        {
            GameManager.instance.CountDown();
        }
    }

    IEnumerator ImOrCrew()
    {
        while (GameManager.instance.players.Count != 4)
        {
            yield return null;
        }

        if (GameManager.instance.players.Count == 4)
        {
            yield return new WaitForSeconds(20.0f);
            intro[1].SetActive(false);

            if (crew == false && imposter == true)
            {
                print(gameObject.GetComponent<PhotonView>().ViewID + "임포스터입니다. 크루원을 모두 죽이세요.");
                intro[3].SetActive(true);
                print("임포스터 UI");
            }

            else
            {
                print(gameObject.GetComponent<PhotonView>().ViewID + "크루원 입니다. 미션을 모두 수행하세요.");
                intro[2].SetActive(true);
                print("크루원 UI");
            }

            yield return new WaitForSeconds(5.0f);
            intro[2].SetActive(false);
            intro[3].SetActive(false);
        }
    }
}



