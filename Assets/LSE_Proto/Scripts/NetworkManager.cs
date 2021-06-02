using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.GameVersion = "0.1";

        int num = Random.Range(0, 100);
        PhotonNetwork.NickName = "Player" + num;

        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = 8 }, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        print("�� ����!");

        //Vector2 originPos = Random.insideUnitCircle * 2.0f;
        Vector2 originPos = new Vector2(54.6f, 5.6f);
        PhotonNetwork.Instantiate("Player", new Vector3(originPos.x, 1.39f, originPos.y), Quaternion.identity);
    }


    void Update()
    {
        
    }
}
