using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPun
{
    public static GameManager instance;

    public Transform[] playerPos;
    public bool[] isEmpty;
    public GameObject wall;
    //public Player myPlayer;

    //Player ��ü���� ����� ����
    public List<Player> players = new List<Player>();

    public void AddPlayer(Player player)
    {
        if (!players.Contains(player))
        {
            players.Add(player);
        }
    }

    private void Awake()
    {
        if (instance == null)
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
        for (int i = 0; i < isEmpty.Length; i++)
        {
            if (isEmpty[i] == false)
            {
                isEmpty[i] = true;
                return playerPos[i].position;
            }
        }

        return Vector3.zero;
    }

    //��Ƶ� Players�迭�� �������� ������ ù��°�� �������ͷ� ����
    IEnumerator ImposterRand()
    {
        while (players.Count != 4)
        {
            yield return null;
        }

        if (PhotonNetwork.IsMasterClient)
        {
            if (players.Count == 4)
            {
                print("����!");
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

                for(int i = 0; i < players.Count; i++)
                {
                    players[i].photonView.RPC("SetImposter", RpcTarget.All, players[i].imposter);
                }
            }
        }
    }


    public void CountDown()
    {
        StartCoroutine(CoCountDown());
    }

    IEnumerator CoCountDown()
    {
        print("�÷��̾ ��� �����Ͽ����ϴ�.");
        Player.instance.countDown.text = "�÷��̾ ��� �����Ͽ����ϴ�.";
        yield return new WaitForSeconds(5.0f);
        print("5�� �ڿ� ������ ���۵˴ϴ�.");
        Player.instance.countDown.text = "5�� �ڿ� ������ ���۵˴ϴ�";
        yield return new WaitForSeconds(5.0f);
        print("5");
        Player.instance.countDown.text = "5";
        yield return new WaitForSeconds(1.0f);
        print("4");
        Player.instance.countDown.text = "4";
        yield return new WaitForSeconds(1.0f);
        print("3");
        Player.instance.countDown.text = "3";
        yield return new WaitForSeconds(1.0f);
        print("2");
        Player.instance.countDown.text = "2";
        yield return new WaitForSeconds(1.0f);
        print("1");
        Player.instance.countDown.text = "1";
        yield return new WaitForSeconds(1.0f);
        print("�������� ���� ��....");
        Player.instance.intro[0].SetActive(false);
        Player.instance.intro[1].SetActive(true);
        yield return new WaitForSeconds(10.0f);
        Destroy(wall);
    }
}
