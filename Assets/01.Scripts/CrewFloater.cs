using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewFloater : MonoBehaviour
{
    //[SerializeField]
    public Image[] crewPre;

    public float timer = 0.5f;
    public float dis = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnFloatingCrew(dis);
            timer = 1f; 
        }
    }

    public void SpawnFloatingCrew(float dist)
    {
        for (int i = 0; i < 100; i++)
        {
            Image tmp;
            int rand1 = Random.Range(0, crewPre.Length);
            int rand2 = Random.Range(0, crewPre.Length);

            tmp = crewPre[rand1];
            crewPre[rand1] = crewPre[rand2];
            crewPre[rand2] = tmp;
        }

        float angle = Random.Range(0f, 360f);
        Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * dis;
        Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        float floSpeed = Random.Range(1f, 4f);
        float rotSpeed = Random.Range(-3f, 3f);

        var crew = Instantiate(crewPre[0], spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
        crew.SetFloatingCrew(dir, floSpeed, rotSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var crew = collision.GetComponent<FloatingCrew>();
        if(crew != null)
        {
            Destroy(crew.gameObject);
        }
    }
}
