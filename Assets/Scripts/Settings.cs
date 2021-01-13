//////////////////////////////////////////
//// Name: Sim McQueen
//// Date: 1/5/21
//// Desc: Fill this with functions for the settings
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    public AudioMixer mixer;

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }



}
