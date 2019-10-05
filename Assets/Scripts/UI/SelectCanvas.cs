using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCanvas : MonoBehaviour
{
    public void PlayClip(AudioClip clip)
    {
        SoundManager.Instance.PlayClip(clip);
    }

    public void LoadLevelScene(int level)
    {
        GameManager.Instance.LoadLevelScene(level);
    }
}
