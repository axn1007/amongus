using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun, IPunObservable
{
    struct SyncData
    {
        public Vector3 pos;
        public Quaternion rotation;
    }

    public GameObject myModel;
    public GameObject otherModel;

    public Transform[] myBody;
    public Transform[] otherBody;

    Transform catchedObj;

    SyncData[] syncData;

    void Start()
    {
        if (photonView.IsMine == false)
        {
            syncData = new SyncData[myBody.Length];
        }

        myModel.SetActive(photonView.IsMine);
        otherModel.SetActive(!photonView.IsMine);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            for (int i = 0; i < myBody.Length; i++)
            {
                stream.SendNext(myBody[i].position);
                stream.SendNext(myBody[i].rotation);
            }
        }

        if (stream.IsReading)
        {
            for (int i = 0; i < myBody.Length; i++)
            {
                syncData[i].pos = (Vector3)stream.ReceiveNext();
                syncData[i].rotation = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}
