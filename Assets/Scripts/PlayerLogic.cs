﻿///////////////////////////////////
//// Name: Sim McQueen
//// Date: 12/14/20
//// Desc: Logic for character
///////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    private Vector3 respawnPos;
    public Color checkActive = new Color(1,0,1,1);
    public Color checkInactive= new Color(1,1,1,1);
    private GameObject currentCheckPoint;
    Renderer rend;
    Color c;
    public GameObject HeartOne;
    public GameObject HeartTwo;
    public GameObject HeartThree;
    private bool flag = true;


    // Start is called before the first frame update
    void Start()
    {
        respawnPos = transform.position;
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        if(GameManager.startingHealth == 1)
        {
            HeartThree.SetActive(false);
            HeartTwo.SetActive(false);

        }
        else if (GameManager.startingHealth == 2)
        {
            HeartThree.SetActive(false);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Respawn if killed
        if(collision.gameObject.CompareTag("Death"))
        {
            transform.position = respawnPos;
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Damage " + GameManager.startingHealth);
            GameManager.startingHealth -= 1;
            Debug.Log("Damage " + GameManager.startingHealth);
            if(GameManager.startingHealth <= 0)
            {
                HeartOne.SetActive(false);
                GameManager.startingHealth = 3;
                transform.position = respawnPos;
                HeartOne.SetActive(true);
                HeartTwo.SetActive(true);
                HeartThree.SetActive(true);
            }
            else if(GameManager.startingHealth == 2)
            {
                HeartThree.SetActive(false);
                StartCoroutine("GetInvulnerable");
            }
            else if (GameManager.startingHealth == 1)
            {
                HeartTwo.SetActive(false);
                StartCoroutine("GetInvulnerable");
            }
            



        }

        if (collision.gameObject.name.Equals ("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }


        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Checkpoint"))
        {
            // Set new location to the new position
            respawnPos = collision.transform.position;

            // Set old checkpoint color back
            if(currentCheckPoint != null)
            {
                currentCheckPoint.GetComponent<SpriteRenderer>().color = checkInactive;
            }

            // Set current checkpoint to the one we just hit
            currentCheckPoint = collision.gameObject;

            // Set new checkpoint color
            if (currentCheckPoint != null)
            {
                currentCheckPoint.GetComponent<SpriteRenderer>().color = checkActive;
            }
        }
        if(collision.gameObject.CompareTag("Heart"))
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



    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.E))
        {
            LevelDoor LD = collision.GetComponent<LevelDoor>();
            if(LD != null)
            {  
                

                if((LD.NextLevel == "Shop") && flag)
                {
                    Debug.Log("Pre-Increase scene count: " + GameManager.SceneCount);
                    GameManager.SceneCount += 1;
                    Debug.Log("Post-Increase scene count: " + GameManager.SceneCount);
                    SceneManager.LoadScene("Shop");
                    Debug.Log("Current scene: " + SceneManager.GetActiveScene().buildIndex);
                    flag = false;


                }

                else if((LD.NextLevel == "ExitShop") && flag)
                {
                    Debug.Log("Current scene: " + SceneManager.GetActiveScene().buildIndex);
                    Debug.Log("Scene count: " + GameManager.SceneCount);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + GameManager.SceneCount);
                    flag = false;
                    
                }
                else if((LD.NextLevel == "EndScreen") && flag)
                {
                    SceneManager.LoadScene("EndScreen");
                }
                
            }
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.startingHealth -= 1;
            Debug.Log("Damage " + GameManager.startingHealth);
            if (GameManager.startingHealth <= 0)
            {
                GameManager.startingHealth = 3;
                transform.position = respawnPos;
            }
        }
    }




    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals ("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        c.a = 1f;
        rend.material.color = c;
    }






    // Update is called once per frame
    void Update()
    {
        
    }
}