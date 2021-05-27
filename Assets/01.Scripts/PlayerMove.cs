using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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
    Animator anim;

    float h;
    float v;

    //�ӷ�
    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;

    public Camera playerCam;

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
                Idle();
                break;
            case PlayerState.Walk:
                Walk();
                break;
            case PlayerState.Attack:
                Attack();
                break;
            case PlayerState.Die:
                Die();
                break;
            case PlayerState.Ghost:
                Ghost();
                break;
            default:
                break;
        }

    }

    void Idle()
    {

        //���� �����÷��� �����ϸ�
        if(h != 0 || v != 0)
        {
            //Walk���·� ����
            state = PlayerState.Walk;
            print("���� ��ȯ : Idle -> Walk");
            //Walk�ִϷ� ����
            anim.SetTrigger("Walk");
        }
        //���� ���ݹ�ư(�����̽�)�� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Attack ���·� ����
            state = PlayerState.Attack;
            print("���� ��ȯ : Idle -> Attack");
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

    void Walk()
    {
        if (h == 0 && v == 0)
        {
            //Walk���·� ����
            state = PlayerState.Idle;
            print("���� ��ȯ : Walk -> Idle");
            //Walk�ִϷ� ����
            anim.SetTrigger("Idle");
        }

        //���� ���ݹ�ư(�����̽�)�� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //Attack ���·� ����
            state = PlayerState.Attack;
            print("���� ��ȯ : Walk -> Attack");
            //Attack �ִϷ� ����
            anim.SetTrigger("Attack");
            isAttack = true;
        }
    }

    void Attack()
    {
        Invoke("AttackKnife", 0.5f);

        currTime += Time.deltaTime;
        if (currTime > attackTime)
        {
            state = PlayerState.Idle;
            anim.SetTrigger("Idle");
            print("���� ��ȯ : Attack -> Idle");

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

    void Die()
    {
        //Ghost ���·� ����
        state = PlayerState.Ghost;
        print("���� ��ȯ : Die -> Ghost");
        //Ghost �ִϷ� ����
        anim.SetTrigger("Ghost");
    }

    void Ghost()
    {
        MoveCtrl();
    }

    public void MoveCtrl()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        //�ؿ��� ������ �Ʒ��� ���ų� ���� ���� ���� �ȴ� ���� transform.Translate(dir * moveSpeed * Time.deltaTime);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void RotCtrl()  //���콺 Up, Down ���� ���� ���� ���� ������� 360�� ���ư��ϱ�   Mathf
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        rotX = Mathf.Clamp(rotX, -90, 90);

        transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        playerCam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
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
