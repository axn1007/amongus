using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    public static GameManager instance;

    public Transform[] playerPos;
    public bool[] isEmpty;
    
    //Player ��ü���� ����� ����
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
    
    //��Ƶ� Players�迭�� �������� ������ ù��°�� �������ͷ� ����
    IEnumerator ImposterRand()
    {
        while(players.Count != 4)
        {
            yield return null;
        }

        if(players.Count == 4)
        {
            StartCoroutine(CountDown());

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
        }
    }
    
    IEnumerator CountDown()
    {
        print("�÷��̾ ��� �����Ͽ����ϴ�.");
        yield return new WaitForSeconds(5.0f);
        print("5�� �ڿ� ������ ���۵˴ϴ�.");
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
        print("�������� ���� ��....");
        yield return new WaitForSeconds(5.0f);
        print("�����");
        yield return new WaitForSeconds(3.0f);
        if (Player.instance.imposter == true)
        {
            print("���������Դϴ�. ũ����� ��� ���̼���.");
        }
        else
        {
            print("ũ��� �Դϴ�. �̼��� ��� �����ϼ���.");
        }
    }

    public void OnClickImporster()
    {
        print("Ŭ��!");

        ////���ӽ��۹�ư�� ������ ����
        //ImposterRand();
        //print("���� Ŭ��!");

        //players[0].imposter = true;
        //players[0].crew = false;

        //for (int i = 1; i < players.Count; i++)
        //{
        //    players[i].imposter = false;
        //    players[i].crew = true;
        //}
    }
}
