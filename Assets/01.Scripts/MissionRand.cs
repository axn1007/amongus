using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MissionRand : MonoBehaviourPun
{
    public List<int> randmis = new List<int>();
    public Text[] texts;


    void Start()
    {
        if (photonView.IsMine)
        {
            randMission();
            missionSetting();
        }
    }

    void Update()
    {
        
    }

    void randMission()
    {
        for (int i = 0; i < 10; i++)
        {
            randmis.Add(i);
        }

        for (int i = 0; i < 100; i++)
        {
            int tamp;
            int rand1 = Random.Range(0, randmis.Count);
            int rand2 = Random.Range(0, randmis.Count);

            tamp = randmis[rand1];
            randmis[rand1] = randmis[rand2];
            randmis[rand2] = tamp;
        }
    }

    public void missionSetting()
    {
        for(int i = 0; i < 4; i++)
        {
            SetMissionText(i + 1, randmis[i]);
        }
    }

    void SetMissionText(int missionOrder, int missionIdx)
    {
        //texts = (missionOrder + "��° �̼���?");
        print(missionOrder + "��° �̼���?");
        Player.instance.mission[missionIdx] = true;
        
        switch(missionIdx)
        {
            case 0:
                texts[missionOrder - 1].text = "�ǹ��ǿ� ���� ��ĵ�ϱ�";
                print("�ǹ��ǿ� ���� ��ĵ�ϱ�");
                break;
            case 1:
                texts[missionOrder - 1].text = "���� �ø���";
                print("���� �ø���");
                break;
            case 2:
                texts[missionOrder - 1].text = "������ ��ȯ�ϱ�";
                print("������ ��ȯ�ϱ�");
                break;
            case 3:
                texts[missionOrder - 1].text = "����� ��ü�ϱ�";
                print("����� ��ü�ϱ�");
                break;
            case 4:
                texts[missionOrder - 1].text = "���� �����ϱ�";
                print("���� �����ϱ�");
                break;
            case 5:
                texts[missionOrder - 1].text = "��ȭ�� ������ �� ����";
                print("��ȭ�� ������ �� ����");
                break;
            case 6:
                texts[missionOrder - 1].text = "���־����� �����ϱ�";
                print("���־����� �����ϱ�");
                break;
            case 7:
                texts[missionOrder - 1].text = "�������� ������";
                print("�������� ������");
                break;
            case 8:
                texts[missionOrder - 1].text = "���� �̵���Ű��";
                print("���� �̵���Ű��");
                break;
            case 9:
                texts[missionOrder - 1].text = "���� �̾Ƽ� ���ּ��� �����ϰ� �����";
                print("���� �̾Ƽ� ���ּ��� �����ϰ� �����");
                break;
            default:
                break;
        }
    }

    //void missionOne()
    //{
    //    print("�̼�1 �ο�");

    //    Text text = GetComponent<Text>();

    //}
}
