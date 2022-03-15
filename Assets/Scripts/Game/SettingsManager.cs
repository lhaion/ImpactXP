using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    private VisualElement settingsOverlay;

    private Slider senseSlider;
    private Slider sfxVolumeSlider;
    private Slider musicVolumeSlider;

    void Awake()
    {
        if (instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            instance = this;
        }
        else if (instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }

        var root = GetComponent<UIDocument>().rootVisualElement;

        senseSlider = root.Q<Slider>("sense-slider");
        sfxVolumeSlider = root.Q<Slider>("sfxvolume-slider");
        musicVolumeSlider = root.Q<Slider>("musicvolume-slider");

        settingsOverlay = root.Q<VisualElement>("SettingsOverlay");

    }

    private void Update()
    {
        if(settingsOverlay.style.visibility.value == Visibility.Visible)
        {
            AudioListener.volume = sfxVolumeSlider.value;
        }
    }


}
