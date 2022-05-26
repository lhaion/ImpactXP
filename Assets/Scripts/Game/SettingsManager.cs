using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    public AudioMixer musicMixer;
    public PlayerMovement playerMovement;

    public GameObject senseSlider, musicSlider, sfxSlider, delaySlider;

    public Game.ScriptableSettings settings;

    void Start()
    {
        senseSlider.GetComponent<Slider>().value = settings.sense;
        SetSense(settings.sense);
        
        delaySlider.GetComponent<Slider>().value = settings.moveDelay;
        SetDelay(settings.moveDelay);
        
        musicSlider.GetComponent<Slider>().value = settings.musicVolume;
        SetMusicVolume(settings.musicVolume);
        
        sfxSlider.GetComponent<Slider>().value = settings.sfxVolume;
        SetSfxVolume(settings.sfxVolume);
        //gameObject.SetActive(false);
    }

    public void SetSense(float newSense)
    {
        settings.sense = newSense;
        if (playerMovement)
            playerMovement.sense = newSense * 5;
    }
    
    public void SetDelay(float newDelay)
    {
        settings.moveDelay = newDelay;
        if (playerMovement)
            playerMovement.smoothTime = newDelay;
    }

    public void SetMusicVolume(float newVolume)
    {
        settings.musicVolume = newVolume;
        musicMixer.SetFloat("musicVolume", Mathf.Log10(newVolume) * 20);
    }
    
    public void SetSfxVolume(float newVolume)
    {
        settings.sfxVolume = newVolume;
        musicMixer.SetFloat("SfxVolume", Mathf.Log10(newVolume) * 20);
    }
}
