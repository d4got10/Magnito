using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public static float MusicVolume = 1;
    public static float EffectsVolume = 1;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("EffectsVolume"))
        {
            MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
            EffectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            MusicVolume = 1;
            EffectsVolume = 1;
        }
        UpdateAllAudioSources();
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = Mathf.Clamp01(value);
        UpdateAllAudioSources();
    }

    public void SetEffectsVolume(float value)
    {
        EffectsVolume = Mathf.Clamp01(value);
        UpdateAllAudioSources();
    }

    public void UpdateAllAudioSources()
    {
        var sources = FindObjectsOfType<MusicOnLoad>();

        foreach (var source in sources)
        {
            source.GetComponent<AudioSource>().volume = MusicVolume;
        }

        UpdateAllAudioVisuals();

        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("EffectsVolume", EffectsVolume);
    }

    public void UpdateAllAudioVisuals()
    {
        var visuals = FindObjectsOfType<MusicVisuals>();

        if (MusicVolume == 0)
        {
            foreach (var visual in visuals)
                visual.TurnOff();
        }
        else
        {
            foreach (var visual in visuals)
                visual.TurnOn();
        }
    }
}
