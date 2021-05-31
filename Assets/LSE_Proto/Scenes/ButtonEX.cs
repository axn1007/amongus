using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPuzzle()
    {
        print("วาทฮ");
        Image puzzleImg = gameObject.GetComponent<Image>();
        puzzleImg.color = Color.red;
        Text tx = GetComponentInChildren<Text>();
        string value = tx.text;
        print(value);
    }
}
