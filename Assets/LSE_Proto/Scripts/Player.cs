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
    public bool vote;
    public int infoNum;

    float currTime;
    float dieTime = 1;

    public int myScore;
    float myGoalScore = 4.0f;
    public Slider mySlider;
    public bool missionComplete;
    int scanCount;
    public int energyCount;
    int btnCount;

    public Text countDown;
    public GameObject[] intro;

    public GameObject knife;
    public GameObject otherKnife;
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
        if (photonView.IsMine)
        {
            GameManager.instance.myPlayer = this;
        }
        infoNum = photonView.OwnerActorNr;
        GameManager.instance.arrayCount[photonView.OwnerActorNr - 1, 0] = photonView.OwnerActorNr;

        if (PhotonNetwork.IsMasterClient)
        {
            Vector3 pos = GameManager.instance.GetEmptyPos();
            photonView.RPC("RpcSetInit", RpcTarget.AllBuffered, pos, infoNum);
            myFirstPos = pos;
        }

        GameManager.instance.AddPlayer(this);

        StartCoroutine(ImOrCrew());
        
        if (photonView.IsMine)
        {
            GameObject go = GameObject.Find("VoteCanvas");
            go.GetComponent<OVRRaycaster>().enabled = true;
        }
        
    }

    void Update()
    {
        UIClick();
        MyMissionBar();
    }

    void UIClick()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            if (crew)
            {
                missionUI.SetActive(true);
                missionBar.SetActive(true);
            }

            if (imposter)
            {
                photonView.RPC("AttackKnife", RpcTarget.All);
            }
        } 
        

        if (Input.GetKeyUp(KeyCode.Alpha1) || OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            if (photonView.IsMine)
            {
                if (crew)
                {
                    missionUI.SetActive(false);
                    missionBar.SetActive(false);
                }

                if (imposter)
                {
                    photonView.RPC("DestroyKnife", RpcTarget.All);
                }
            }
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

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "knife")
        {
            print(imposter);
            if (imposter == true) return;

            currTime += Time.deltaTime;
            if (currTime > dieTime)
            {
                photonView.RPC("BeGhost", RpcTarget.All);

                currTime = 0;
            }
        }

    }

    void MyMissionBar()
    {
        mySlider.value = myScore;

        if(myScore == myGoalScore)
        {
            missionComplete = true;
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

    public void ScanMission(int count)
    {
        scanCount += count;
        print(scanCount);
        if (scanCount == 4)
        {
            print("ScanMission Complete");
            myScore += 1;
        }
    }

    public void EnergyMission(int count)
    {
        energyCount += count;

        if (energyCount == 1)
        {
            myScore += 1;
            print("EnergyMission Complete");
        }
    }

    public void ButtonMission(int count)
    {
        btnCount += count;

        if (btnCount == 2)
        {
            print("PressButtonMission Complete");
            myScore += 1;
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
    void MoveVentPos(Vector3 p)
    {
        transform.position = p;
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

    [PunRPC]
    void AddCount(int i)
    {
        GameManager.instance.AddCount(i);
    }

    [PunRPC]
    void BeGhost()
    {
        if (photonView.IsMine)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}