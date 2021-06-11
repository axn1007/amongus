using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewCreate1 : MonoBehaviour
{
    //[SerializeField]
    public GameObject[] crewFactory;

    public Image image;

    //목적지
    public GameObject pos;

    
    void Start()
    {
        StartCoroutine(createCrewProc());
    }

    void Update()
    {
        
    }

    IEnumerator createCrewProc()
    {
        while(true)
        {
            crewRandom();

            yield return new WaitForSeconds(7.0f);
        }
    }

    void crewRandom()
    {
        int crewFac = Random.Range(0, crewFactory.Length);
        GameObject crew = Instantiate(crewFactory[crewFac], image.transform);

        //만들어진 crew의 부모를 Image의 transform으로 한다
        //crew.transform.SetParent(image.transform);

        crew.transform.position = transform.position;

        iTween.MoveTo(crew, iTween.Hash("position", pos.transform.position,
                                        "x", 1.0f,
                                        "Time", 4.0f,
                                        "easeType", iTween.EaseType.easeInOutBounce
                                        /*"looptype", iTween.LoopType.pingPong*/));
    }
}
