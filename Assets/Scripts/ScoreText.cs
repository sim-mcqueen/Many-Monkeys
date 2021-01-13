/////////////////////////////
//// Name: Sim McQueen
//// Date: 1/7/21
//// Desc: Changes the text of the score game object
/////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI myTMP;



    // Start is called before the first frame update
    void Start()
    {
        myTMP = GetComponent<TextMeshProUGUI>();
        GameManager.OnScoreUpdate.AddListener(UpdateText);
        UpdateText();
    }

    
    private void UpdateText()
    {
        myTMP.text = "" + GameManager.Score;
    }
}
