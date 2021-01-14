/////////////////////////////
//// Name: Sim McQueen
//// Date: 1/7/21
//// Desc: The game manager allows you to store varaibles when there should be only one instance of it
/////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static int score = 50;

    public static UnityEvent OnScoreUpdate = new UnityEvent();

    public static int startingHealth = 3;

    public static int Score
    {
        get => score;
        set
        {
            score = value;

            OnScoreUpdate.Invoke();
        }
    }

    


}
