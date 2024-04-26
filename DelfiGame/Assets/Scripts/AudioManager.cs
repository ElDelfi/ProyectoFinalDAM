using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake() //antes del start
    {
        if (instance == null) //para que solo exista uno si no se duplica al pasar entre escensa
        {
            instance = this;
        }else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this); //para que no desaparezca al psar entre scenes
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume=s.volume;
            s.source.pitch=s.pitch;
            s.source.loop=s.loop;
        }
    }

    public void Play(string name) { //para buscar el audio que queremos usar
        Sound s=Array.Find(sounds, sound => sound.name == name);
        s.source.Play();   
    }

    void Start()
    {
        //aqui poner en main theme
        FindObjectOfType<AudioManager>().Play("Theme");
    }
}

//para usarlo FindObjectOfType<AudioManager>().Play("cadena");