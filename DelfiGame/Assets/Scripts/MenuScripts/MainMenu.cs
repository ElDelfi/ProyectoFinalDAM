using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //podemos ver el orden y añadirles en FILE->BUILD SETTINGS
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
