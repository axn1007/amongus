using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    Vector3 dir;
    public float floSpeed;
    public float rotSpeed;

    public void SetFloatingCrew(Vector3 dir, float floSpeed, float rotSpeed)
    {
        this.dir = dir;
        this.floSpeed = floSpeed;
        this.rotSpeed = rotSpeed;
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += dir * floSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotSpeed));
    }
}
