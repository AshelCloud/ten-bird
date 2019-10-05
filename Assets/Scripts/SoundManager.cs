using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource Audio { get; private set; }

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    public void PlayClip(AudioClip clip)
    {
        Audio.PlayOneShot(clip);
    }
}
