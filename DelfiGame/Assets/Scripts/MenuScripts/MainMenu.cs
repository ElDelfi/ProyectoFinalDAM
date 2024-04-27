using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider sliderMusic;
    public Slider sliderSFX;
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //podemos ver el orden y añadirles en FILE->BUILD SETTINGS
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("MusicValue", 0f);
        sliderSFX.value = PlayerPrefs.GetFloat("SFXValue", 0f);
    }

}
