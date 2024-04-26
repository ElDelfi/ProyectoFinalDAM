using UnityEngine;
using UnityEngine.Audio;

[System.Serializable] //al ser clase custom para qu aparezca en el editor
public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
