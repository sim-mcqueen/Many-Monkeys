/****************
* Name: Andrew Dahlman-Oeth
* Date: 1/12/2021
* Desc: Put onto GameObjects to purchase
****************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public int price = 10;
    public bool rebuy;
    public float cooldown = 0.5f;
    private float timePassed = 0f;
   
    // Update is called once per frame
    void Update () 
    {
        timePassed += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(timePassed >= cooldown)
                {
                    if(GameManager.Score >= price)
                    {
                        GameManager.Score = GameManager.Score - price;
                        timePassed = 0f;
                    }
                }
                
            }
        }
}
