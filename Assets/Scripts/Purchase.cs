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
    public bool cooldown;
    public Upgrades upgrade = new Upgrades();
    [Tooltip("Amount to CHANGE the above upgrade by")]
    public float amount;

    void Start()
    {
        GameManager.OnPurchase.AddListener(UpgradePlayer);
    }

    private void UpgradePlayer()
    {
        Debug.Log("In upgrade");
        
        if(upgrade.ToString() == "Speed")
        {
            GameManager.Speed += amount;
        }   
        else if(upgrade.ToString() == "JumpHeight")
        {
            GameManager.JumpHeight += amount;
        }
        else if (upgrade.ToString() == "JumpAmount")
        {
            GameManager.JumpAmount += (int) amount;
        }
        else
        {
            Debug.Log("None Selected");
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
        {
            if(Input.GetKey(KeyCode.E))
            {
                if(cooldown == false)
                {
                    if(GameManager.Score >= price)
                    {

                        GameManager.Score = GameManager.Score - price;
                        GameManager.OnPurchase.Invoke();


                        Invoke("ResetCooldown", 0.25f);
                        cooldown = true;
                        if(!rebuy)
                        {
                            Destroy(this);
                        }
                    }
                }
                
            }
        }
}
public enum Upgrades
    {
        Speed,
        JumpHeight,
        JumpAmount
    };
