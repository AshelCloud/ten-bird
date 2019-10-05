using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _audio;
    public AudioSource Audio
    {
        get
        {
            if(_audio == null)
            {
                _audio = GetComponent<AudioSource>();
            }
            return _audio;
        }
        set
        {
            _audio = value;
        }
    }

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    public void PlayClip(AudioClip clip)
    {
        Audio.PlayOneShot(clip);
    }

    public void PlayLoop(AudioClip clip)
    {
        Audio.clip = clip;
        Audio.loop = true;
        Audio.Play();
    }
}
