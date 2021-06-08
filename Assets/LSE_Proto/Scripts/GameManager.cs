using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    public static GameManager instance;

    public Transform[] playerPos;
    public bool[] isEmpty;
    
    //Player 객체들이 저장될 변수
    public List<Player> players = new List<Player>();

    public void AddPlayer(Player player)
    {
        if(!players.Contains(player))
        {
            players.Add(player);
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //Screen.SetResolution(960, 640, FullScreenMode.Windowed);


        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 30;

        isEmpty = new bool[playerPos.Length];

        StartCoroutine(ImposterRand());
    }

    void Update()
    {
        
    }

    public Vector3 GetEmptyPos()
    {
        for(int i = 0; i<isEmpty.Length; i++)
        {
            if(isEmpty[i] == false)
            {
                isEmpty[i] = true;
                return playerPos[i].position;
            }
        }

        return Vector3.zero;
    }
    
    //담아둔 Players배열을 랜덤으로 돌려서 첫번째를 임포스터로 선정
    IEnumerator ImposterRand()
    {
        while(players.Count != 4)
        {
            yield return null;
        }

        if(players.Count == 4)
        {
            StartCoroutine(CountDown());

            print("랜덤!");
            for (int i = 0; i < 100; i++)
            {
                Player tamp;
                int rand1 = Random.Range(0, players.Count);
                int rand2 = Random.Range(0, players.Count);

                tamp = players[rand1];
                players[rand1] = players[rand2];
                players[rand2] = tamp;
            }

            players[0].imposter = true;
            players[0].crew = false;

            for (int i = 1; i < players.Count; i++)
            {
                players[i].imposter = false;
                players[i].crew = true;
            }
        }
    }
    
    IEnumerator CountDown()
    {
        print("플레이어가 모두 입장하였습니다.");
        yield return new WaitForSeconds(5.0f);
        print("5초 뒤에 게임이 시작됩니다.");
        yield return new WaitForSeconds(5.0f);
        print("5");
        yield return new WaitForSeconds(1.0f);
        print("4");
        yield return new WaitForSeconds(1.0f);
        print("3");
        yield return new WaitForSeconds(1.0f);
        print("2");
        yield return new WaitForSeconds(1.0f);
        print("1");
        yield return new WaitForSeconds(1.0f);
        print("임포스터 선정 중....");
        yield return new WaitForSeconds(5.0f);
        print("당신은");
        yield return new WaitForSeconds(3.0f);
        if (Player.instance.imposter == true)
        {
            print("임포스터입니다. 크루원을 모두 죽이세요.");
        }
        else
        {
            print("크루원 입니다. 미션을 모두 수행하세요.");
        }
    }

    public void OnClickImporster()
    {
        print("클릭!");

        ////게임시작버튼을 누르면 랜덤
        //ImposterRand();
        //print("랜덤 클릭!");

        //players[0].imposter = true;
        //players[0].crew = false;

        //for (int i = 1; i < players.Count; i++)
        //{
        //    players[i].imposter = false;
        //    players[i].crew = true;
        //}
    }
}
