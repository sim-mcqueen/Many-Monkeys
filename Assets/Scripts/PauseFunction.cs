/******************************
 * Name: Sim McQueen
 * Date: 1/4/2021
 * Desc: Allows pausing in game
 * ****************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunction : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenu;
    public GameObject GameUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseMenu.SetActive(true);
        GameUI.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenu.SetActive(false);
        GameUI.SetActive(true);
    }


    public void Stop()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}