using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STManager : MonoBehaviour
{
    //�����ð�
    public int createTime = 0;
    //����ð�
    float currTime;
    //SpaceTrash����
    public GameObject STFactory;

    //���ӽð�
    float gameTime = 20;

    void Start()
    {
        createTime = Random.Range(3, 10);
        StartCoroutine(CreateSTProc());
    }

    void Update()
    {
        currTime += Time.deltaTime;
    }

    IEnumerator CreateSTProc()
    {
        while (currTime < gameTime)
        {
            yield return new WaitForSeconds(createTime);

            //���忡�� ���־����� ����
            GameObject ST = Instantiate(STFactory); ;
            //���־����⸦ ���־�����Ŵ��� ��ġ�� ���´�
            ST.transform.position = transform.position;

        }
        yield return new WaitForSeconds(5);
        print("Mission Clear!!!!!");
    }

}
