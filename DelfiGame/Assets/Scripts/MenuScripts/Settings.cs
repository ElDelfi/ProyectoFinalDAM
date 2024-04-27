using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider sliderMusic;
    public Slider sliderSFX;

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("MusicValue", volume);
    }
    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFXValue", volume);
    }


    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicValue", sliderMusic.value);
        PlayerPrefs.SetFloat("SFXValue", sliderSFX.value);
    }
}
