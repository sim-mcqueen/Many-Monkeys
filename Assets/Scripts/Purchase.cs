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
    private float timeStamp;
    

    private void OnTriggerStay2D(Collider2D collision)
        {
            if(Input.GetKey(KeyCode.E))
            {
                if(timeStamp <= Time.time)
                {
                    if(GameManager.Score >= price)
                    {
                        timeStamp = Time.time + cooldown;
                        GameManager.Score = GameManager.Score - price;
                        if(!rebuy)
                        {
                            Destroy(this);
                        }
                    }
                }
            }
        }
}
