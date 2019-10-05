using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCanvas : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayLoop(Resources.Load<AudioClip>("Sounds/suzaku"));
    }

    public void PlayClip(AudioClip clip)
    {
        SoundManager.Instance.PlayClip(clip);
    }

    public void LoadLevelScene(int level)
    {
        GameManager.Instance.LoadLevelScene(level);
    }
}
