///////////////////////////////////////////
//// Name: Sim McQueen
//// Date: 1/6/21
//// Desc: Allows the player to press the down key to get off certain platforms
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    private float baseWaitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        baseWaitTime = waitTime;
    }


    void Update()
    {

        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = baseWaitTime;
        }



        if(Input.GetKey(KeyCode.S))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = baseWaitTime;
            } 
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }

    }

}
