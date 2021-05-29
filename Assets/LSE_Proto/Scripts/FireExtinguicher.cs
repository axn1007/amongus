using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguicher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "vent") return;

        Destroy(gameObject);
        Destroy(other.gameObject);
        MissionManager.instance.FireMission(1);
    }
}
