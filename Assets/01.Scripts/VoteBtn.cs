using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteBtn : MonoBehaviour
{
    //Button[] btn;
    int count;

    void Start()
    {
        //btn = new Button[]
        //{
        //    Canvas. Find("VoteBtn/Button"),
        //    GameObject.Find("VoteBtn/Button1"),
        //    GameObject.Find("VoteBtn/Button2"),
        //    GameObject.Find("VoteBtn/Button3"),
        //    GameObject.Find("VoteBtn/Button4"),
        //    GameObject.Find("VoteBtn/Button5"),
        //    GameObject.Find("VoteBtn/Button6"),
        //    GameObject.Find("VoteBtn/Button7"),
        //};
    }

    void Update()
    {
        
    }

    public void OnClickVoteBtn()
    {
        print( "버튼이 눌렸습니다");
        count++;
    }
    public void OnClickVoteBtn1()
    {
        print("버튼1이 눌렸습니다");
        count++;
    }
    public void OnClickVoteBtn2()
    {
        print("버튼2이 눌렸습니다");
        count++;
    }
    public void OnClickVoteBtn3()
    {
        print("버튼3이 눌렸습니다");
        count++;
    }
    public void OnClickVoteBtn4()
    {
        print("버튼4이 눌렸습니다");
        count++;
    }
    public void OnClickVoteBtn5()
    {
        print("버튼5이 눌렸습니다");
        count++;
    }
    public void OnClickVoteBtn6()
    {
        print("버튼6이 눌렸습니다");
        count++;
    }
    public void OnClickVoteBtn7()
    {
        print("버튼7이 눌렸습니다");
        count++;
    }
}
