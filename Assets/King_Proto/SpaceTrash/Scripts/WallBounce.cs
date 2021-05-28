using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    [SerializeField] [Range(200f, 2000f)] float speed = 1000f;
    public Rigidbody rb;
    float randomX, randomY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        randomX = Random.Range(-1f, 1f);
        randomY = Random.Range(-1f, 1f);

        Vector2 dir = new Vector2(randomX, randomY).normalized;

        rb.AddForce(dir * speed);
    }

    void Update()
    {
        
    }
}
