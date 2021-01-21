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
    SpriteRenderer rend;
    Color curcolor;
    public GameObject HeartOne;
    public GameObject HeartTwo;
    public GameObject HeartThree;

    void Start()
    {
        GameManager.OnPurchase.AddListener(UpgradePlayer);
        rend = GetComponent<SpriteRenderer>();
        curcolor = rend.color;
        // if(price > GameManager.Score)
        // {
        //     rend.color = new Color(0.5f, 0.5f, 0.5f, 1);
        // }
    }
    IEnumerator InsufficientFunds()
    {
        rend.color = new Color(0.5f, 0, 0, 1);
        yield return new WaitForSeconds(0.3f);
        rend.color = curcolor;
    }
    IEnumerator SufficientFunds()
    {
        rend.color = new Color(0, 0.5f, 0, 1);
        yield return new WaitForSeconds(0.3f);
        rend.color = curcolor;
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
        else if (upgrade.ToString() == "Health")
        {
            if(GameManager.startingHealth < 3)
            {
                GameManager.startingHealth += 1;
                if(GameManager.startingHealth == 2)
                {
                    HeartTwo.SetActive(true);
                }
                else if(GameManager.startingHealth == 3)
                {
                    HeartThree.SetActive(true);
                }
            }
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
                        StartCoroutine(SufficientFunds());
                        GameManager.Score = GameManager.Score - price;
                        GameManager.OnPurchase.Invoke();


                        Invoke("ResetCooldown", 0.25f);
                        cooldown = true;
                        if(!rebuy)
                        {
                            Destroy(this);
                        }
                    }
                    else
                    {
                        StartCoroutine(InsufficientFunds());
                    }
                }
                
            }
        }
}
public enum Upgrades
    {
        Speed,
        JumpHeight,
        JumpAmount,
        Health
    };
