using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public static Puzzle instance ;

    public List<RawImage> image = new List<RawImage>();
    public List<int> num = new List<int>();

    //비교할 변수
    public List<string> clearNum = new List<string>();
    //클릭한 숫자 담을 변수
    public List<string> clickValue = new List<string>();

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Suffle();
        Setting();
        
    }

    void Update()
    {
        ClearClickNum();
    }

    void Suffle()
    {
        for (int i = 0; i < 100; i++)
        {
            int tmp;
            int rand1 = Random.Range(0, num.Count);
            int rand2 = Random.Range(0, num.Count);

            tmp = num[rand1];
            num[rand1] = num[rand2];
            num[rand2] = tmp;
        }
    }

    public void Setting()
    {
        for (int i = 0; i < image.Count; i++)
        {
            Text tx = image[i].GetComponentInChildren<Text>();
            tx.text = num[i].ToString();
        }
    }

    public void ClearClickNum()
    {
        if(clearNum.Count != clickValue.Count) return;
        
        
            for (int i = 0; i < clickValue.Count; i++)
            {
                if (clickValue[i] != clearNum[i])
                {
                    print("Mission Failed");
                    return;
                }
            }
            print("Mission Clear!!!!!!!");
    }
    
}

