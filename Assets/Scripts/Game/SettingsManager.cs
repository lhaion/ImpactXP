using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    public AudioMixer musicMixer;

    public GameObject senseSlider, musicSlider, sfxSlider;

    public Game.ScriptableSettings settings;

    void Start()
    {
        senseSlider.GetComponent<Slider>().value = settings.sense;
        SetSense(settings.sense);
        musicSlider.GetComponent<Slider>().value = settings.musicVolume;
        SetMusicVolume(settings.musicVolume);
        sfxSlider.GetComponent<Slider>().value = settings.sfxVolume;
        SetSfxVolume(settings.sfxVolume);
        //gameObject.SetActive(false);
    }

    public void SetSense(float newSense)
    {
        settings.sense = newSense;
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
