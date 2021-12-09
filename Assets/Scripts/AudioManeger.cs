using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManeger : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.souce = gameObject.AddComponent<AudioSource>();
            s.souce.clip = s.clip;
            s.souce.volume = s.volume;
            s.souce.pitch = s.pitch;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.souce.Play();
    }
}
