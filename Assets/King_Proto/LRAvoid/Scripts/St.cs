using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St : MonoBehaviour
{
    public float speed = 2;

    void Start()
    {
        
    }

    void Update()
    {
        //Vector3 dir = new Vector3(0, 1, 0);
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            print("�÷��̾�� �浹");
            Destroy(gameObject);
        }
        if(collision.gameObject.layer == 6)
        {
            print("�ٴڰ� �浹");
            Destroy(gameObject);
        }
    }
}
