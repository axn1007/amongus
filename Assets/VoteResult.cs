using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteResult : MonoBehaviour
{
    public static VoteResult instance;

    public GameObject[] crewFactory;

    public Image image;

    //������
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

        //������� crew�� �θ� Image�� transform���� �Ѵ�
        //crew.transform.SetParent(image.transform);

        crew.transform.position = transform.position;

        iTween.MoveTo(crew, iTween.Hash("position", pos.transform.position,
                                        "x", 1.0f,
                                        "Time", 6.0f,
                                        "easeType", iTween.EaseType.easeInQuint
                                        /*"looptype", iTween.LoopType.pingPong*/));
    }
}
