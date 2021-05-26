using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�ӷ�
    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;

    public Camera playerCam;

    //�߷�
    //float gravity = -9.8f;
    

    void Start()
    {

    }

    void Update()
    {
        //Player �̵�
        MoveCtrl();
        //ȭ�� ��ȯ
        RotCtrl();
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
}
