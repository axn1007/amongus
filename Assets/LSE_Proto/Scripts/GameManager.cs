using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(960, 640, FullScreenMode.Windowed);

        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 30;
    }

    void Update()
    {
        
    }
}
