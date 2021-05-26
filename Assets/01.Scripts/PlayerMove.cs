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

    void Start()
    {
        //���� ���� ������ Idle ����
        state = PlayerState.Idle;
        anim.SetTrigger("Idle");
    }

    void Update()
    {
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
        
        {
            //Walk���·� ����
            state = PlayerState.Walk;
            print("���� ��ȯ : Idle -> Walk");
            //Walk�ִϷ� ����
            anim.SetTrigger("Walk");
        }
        //���� ���ݹ�ư(�����̽�)�� ������
        if (Input.GetKey(KeyCode.Space))
        {
            //Attack ���·� ����
            state = PlayerState.Attack;
            print("���� ��ȯ : Idle -> Attack");
            //Attack �ִϷ� ����
            anim.SetTrigger("Attack");
        }

    }

    void Walk()
    {
        MoveCtrl();

        //���� ���ݹ�ư(�����̽�)�� ������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Attack ���·� ����
            state = PlayerState.Attack;
            print("���� ��ȯ : Walk -> Attack");
            //Attack �ִϷ� ����
            anim.SetTrigger("Attack");
        }
    }

    void Attack()
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
        state = PlayerState.Walk;
        print("���� ��ȯ : Attack -> Walk");
    }

    void Die()
    {
        //Ghost ���·� ����
        state = PlayerState.Ghost;
        print("���� ��ȯ : Die -> Ghost");
        //Ghost �ִϷ� ����
        anim.SetTrigger("Walk");
    }

    void Ghost()
    {
        //�ȱ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        //�ؿ��� ������ �Ʒ��� ���ų� ���� ���� ���� �ȴ� ���� transform.Translate(dir * moveSpeed * Time.deltaTime);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void MoveCtrl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

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

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Knife")
        {
            Destroy(gameObject);
            state = PlayerState.Die;
        }
    }
}
