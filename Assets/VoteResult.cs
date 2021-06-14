using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteResult : MonoBehaviour
{
    public static VoteResult instance;

    public GameObject[] crewFactory;

    public Image image;

    //목적지
    public GameObject pos;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(createCrewProc());
    }

    void Update()
    {

    }

    IEnumerator createCrewProc()
    {
        while (true)
        {
            crewRandom();

            yield return new WaitForSeconds(5.0f);
        }
    }

    public void crewRandom()
    {
        int crewFac = GameManager.instance.infoIdx;

        GameObject crew = Instantiate(crewFactory[crewFac], image.transform);

        //만들어진 crew의 부모를 Image의 transform으로 한다
        //crew.transform.SetParent(image.transform);

        crew.transform.position = transform.position;

        iTween.MoveTo(crew, iTween.Hash("position", pos.transform.position,
                                        "x", 1.0f,
                                        "Time", 6.0f,
                                        "easeType", iTween.EaseType.easeInQuint
                                        /*"looptype", iTween.LoopType.pingPong*/));
    }
}
