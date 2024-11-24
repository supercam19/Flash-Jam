using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public bool bgMusic = true;
    public static AudioManager instance;
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        if (bgMusic)
        {
            Play("vov");
        }
    }
    void FixedUpdate()
    { 
    
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds,sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }
        
    }
    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if (!s.source.isPlaying)
            {
                s.source.Play();
            }
            
        }

    }
    public void PlayAndCancel(string nameA,string nameB)
    {
        Sound splay = Array.Find(sounds, sound => sound.name == name);
        Sound scancel = Array.Find(sounds, sound => sound.name == name);
        if (splay != null)
        {
            if(scancel != null&& scancel.source.isPlaying)
            {
                scancel.source.Stop();
            }
            if (splay.source.isPlaying)
            {
                splay.source.Stop();
            }
            splay.source.Play();
        }

    }
    public void PitchVolumeMove(string name, float modifier)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.pitch = Mathf.Clamp(modifier, 0.1f, 1f);
            s.source.volume = Mathf.Clamp(modifier, 0.1f, 0.5f);

        }

    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Stop();
        }
    }
}
