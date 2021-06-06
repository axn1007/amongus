using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Vector3 pos = GameManager.instance.GetEmptyPos();
            photonView.RPC("RpcSetInit", RpcTarget.AllBuffered, pos);
        }
    }

    void Update()
    {
        
    }

    [PunRPC]
    void RpcSetInit(Vector3 pos)
    {
        transform.position = pos + new Vector3(0, 1.39f, 0);
    }
}
