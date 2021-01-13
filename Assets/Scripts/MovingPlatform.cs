////////////////////////////////
//// Name: Sim McQueen
//// Date: 1/6/21
//// Desc: Allows a platform to move from one point to another
////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float dirX, moveSpeed = 3f;
    bool moveRight = true;
    public float rightMostPos;
    public float leftMostPos;


    void Update()
    {
        if (transform.position.x > rightMostPos)
        {
            moveRight = false;
        }
        if (transform.position.x < leftMostPos)
        {
            moveRight = true;
        }

        if(moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

}
