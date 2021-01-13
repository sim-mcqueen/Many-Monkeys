////////////////////////////////
//// Name: Sim McQueen
//// Date: 1/7/21
//// Desc: Allows an object to be collected for points
////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollectable : MonoBehaviour
{
    public int points = 10;

    public bool destroyOnCollide = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Trigger");

        GameManager.Score += points;
        if(destroyOnCollide)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Score += points;
        if (destroyOnCollide)
        {
            Destroy(gameObject);
        }
    }


}
