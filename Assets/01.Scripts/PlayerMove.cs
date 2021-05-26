using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //속력
    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;

    public Camera playerCam;

    //중력
    //float gravity = -9.8f;
    

    void Start()
    {

    }

    void Update()
    {
        //Player 이동
        MoveCtrl();
        //화면 전환
        RotCtrl();
    }

    void MoveCtrl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        //밑에랑 같은거 아래를 보거나 위를 봐도 땅을 걷는 느낌 transform.Translate(dir * moveSpeed * Time.deltaTime);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        transform.position += dir * moveSpeed * Time.deltaTime;

    }

    void RotCtrl()  //마우스 Up, Down 각도 제한 범위 설정 해줘야함 360도 돌아가니까   Mathf
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        rotX = Mathf.Clamp(rotX, -90, 90);

        transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        playerCam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
    }
}
