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
    private static int score = 0;

    private static float speed = 5f;
    
    private static float jumpheight = 5f;

    private static int jumpamount = 2;
    
    public static int startingHealth = 3;
    
    private static int sceneCount = 1;

    public static UnityEvent OnScoreUpdate = new UnityEvent();

    public static UnityEvent OnPurchase = new UnityEvent();

    public static int SceneCount
    {
        get => sceneCount;
        set
        {
            sceneCount = value;
        }
    }

    public static int Score
    {
        get => score;
        set
        {
            score = value;

            OnScoreUpdate.Invoke();
        }
    }

    public static float Speed
    {
        get => speed;
        set
        {
            speed = value;
        }
    }

    public static float JumpHeight
    {
        get => jumpheight;
        set
        {
            jumpheight = value;
        }
    }

    public static int JumpAmount
    {
        get => jumpamount;
        set
        {
            jumpamount = value;
        }
    }

    


}
