/////////////////////////////////
//// Name: Sim McQueen
//// Date: 1/4/21
//// Desc: Functions for buttons and things for the menu
/////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    [Tooltip("What level do you want to go to")]
    public string NextLevel;

    public void Play()
    {
        Debug.Log("The game has started. Level:" + NextLevel);
        SceneManager.LoadScene(NextLevel);



    }

    public void Stop()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }


}
