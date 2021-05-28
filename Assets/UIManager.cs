using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] vent;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickMainRoom()
    {
        player.transform.position = vent[0].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickFirstZone()
    {
        player.transform.position = vent[1].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickSecondZone()
    {
        player.transform.position = vent[2].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickThirdZone()
    {
        player.transform.position = vent[3].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }

    public void OnClickForthZone()
    {
        player.transform.position = vent[4].transform.position + new Vector3(0, 1, 0);
        Vent.instance.ventUI.SetActive(false);
    }
}
