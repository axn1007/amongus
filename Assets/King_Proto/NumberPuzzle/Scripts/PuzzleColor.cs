using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleColor : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickColorChange()
    {
        print("Ŭ��");
        Image im = GetComponent<Image>();
        im.color = Color.gray;

        //Ŭ���ϸ� �ٽ� ��������
        Button btn = GetComponentInChildren <Button>();
        btn.interactable = false;

        //Ŭ���� �� ���
        Text tx = GetComponentInChildren<Text>();
        string ct = tx.text;
        Puzzle.instance.clickValue.Add(ct);

        
    }
}
