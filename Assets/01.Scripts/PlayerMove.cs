using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun, IPunObservable
{

    Vector3 setPos;
    Quaternion setRot;
    float dir_speed = 0;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(anim.GetFloat("Speed"));
        }

        else if (stream.IsReading)
        {
            setPos = (Vector3)stream.ReceiveNext();
            setRot = (Quaternion)stream.ReceiveNext();
            dir_speed = (float)stream.ReceiveNext();
        }
    }


    enum PlayerState
    {
        Idle,
        Walk,
        Attack,
        Die,
        Ghost
    }

    PlayerState state;

    //�ִϸ�����
    public Animator anim;

    float h;
    float v;

    //�ӷ�
    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;

    public GameObject playerCam;

    public int rotSpe = 60;

    //Knife ����
    public GameObject knifeFactory;
    //�߻���ġ
    public Transform firePos;
    //������ ��
    public float throwPower =100;

    bool isAttack;

    float currTime;
    float attackTime = 1.5f;

    void Start()
    {
        playerCam.SetActive(photonView.IsMine);

        //���� ���� ������ Idle ����
        state = PlayerState.Idle;

        //Animator ����
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        MoveCtrl();
        RotCtrl();

        //���¿� ���� ������ ��� ����
        switch (state)
        {
            case PlayerState.Idle:
                photonView.RPC("Idle", RpcTarget.All);
                break;
            case PlayerState.Walk:
                photonView.RPC("Walk", RpcTarget.All);
                break;
            case PlayerState.Attack:
                photonView.RPC("Attack", RpcTarget.All);
                break;
            case PlayerState.Die:
                photonView.RPC("Die", RpcTarget.All);
                break;
            //case PlayerState.Ghost:
            //    Ghost();
            //    break;
            default:
                break;
        }

    }

    [PunRPC]
    void Idle()
    {

        //���� �����÷��� �����ϸ�
        if(v != 0)
        {
            //Walk���·� ����
            state = PlayerState.Walk;
            //Walk�ִϷ� ����
            anim.SetTrigger("Walk");
        }
        //���� ���ݹ�ư(�����̽�)�� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Attack ���·� ����
            state = PlayerState.Attack;
            //Attack �ִϷ� ����
            anim.SetTrigger("Attack");
            isAttack = true;
        }
        //���� Į�� ������
        
        {
            //Die ���·� ����
            //Die �ִϷ� ����
        }
    }

    [PunRPC]
    void Walk()
    {
            if (v == 0)
            {
                //Walk���·� ����
                state = PlayerState.Idle;
                //Walk�ִϷ� ����
                anim.SetTrigger("Idle");
            }

            //���� ���ݹ�ư(�����̽�)�� ������
            if (Input.GetKeyDown(KeyCode.Space))
            {

                //Attack ���·� ����
                state = PlayerState.Attack;
                //Attack �ִϷ� ����
                anim.SetTrigger("Attack");
                isAttack = true;
            }
        
    }

    [PunRPC]
    void Attack()
    {
        Invoke("AttackKnife", 0.5f);

        currTime += Time.deltaTime;
        if (currTime > attackTime)
        {
            state = PlayerState.Idle;
            anim.SetTrigger("Idle");
       
            currTime = 0;
        }
    }

    void AttackKnife()
    {
        if (isAttack == true)
        {
            //Į ���忡�� Į �����ؼ� �߻�
            GameObject knife = Instantiate(knifeFactory);
            ////������� Į�� �߻���ġ�� ��ġ��Ű��
            knife.transform.position = firePos.position;
            knife.transform.forward = new Vector3(firePos.forward.x, 0, firePos.forward.z);
            //(�߷������� �������� �Ϸ���)rigidbody ��������
            Rigidbody rb = knife.GetComponent<Rigidbody>();
            //ī�޶� �ٶ󺸴� �������� �������� ���� ���Ѵ�
            rb.AddForce(Camera.main.transform.forward * throwPower);
        }

        isAttack = false;
    }

    [PunRPC]
    void Die()
    {
        //Ghost ���·� ����
        state = PlayerState.Ghost;
        //Ghost �ִϷ� ����
        anim.SetTrigger("Ghost");
    }
    /*
    void Ghost()
    {
        MoveCtrl();
    }
    */

    void MoveCtrl()
    {
        if (photonView.IsMine)
        {
            v = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(0, 0, v);
            dir.Normalize();

            //�ؿ��� ������ �Ʒ��� ���ų� ���� ���� ���� �ȴ� ���� transform.Translate(dir * moveSpeed * Time.deltaTime);
            dir = Camera.main.transform.TransformDirection(dir);
            dir.y = 0;

            transform.position += dir * moveSpeed * Time.deltaTime;

            Vector2 joyStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

            transform.Rotate(0, joyStick.x * rotSpe * Time.deltaTime, 0);
        }

        else
        {
            transform.position = Vector3.Lerp(transform.position, setPos, 0.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, setRot, 0.2f);

            anim.SetFloat("Speed", dir_speed);
        }
        
    }

    void RotCtrl()  //���콺 Up, Down ���� ���� ���� ���� ������� 360�� ���ư��ϱ�   Mathf
    {
        if (photonView.IsMine)
        {
            float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
            float rotY = Input.GetAxis("Mouse X") * rotSpeed;

            rotX = Mathf.Clamp(rotX, -90, 90);

            transform.localRotation *= Quaternion.Euler(0, rotY, 0);
            Camera.main.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Knife")
        {
            Destroy(gameObject, 1);
            state = PlayerState.Die;
        }
    }
}
