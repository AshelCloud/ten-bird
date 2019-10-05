using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int Level { get; set; }

    [SerializeField]
    private FadeImage _fade;
    private FadeImage Fade
    {
        get
        {
            if(_fade == null)
            {
                _fade = GameObject.FindObjectOfType(typeof(FadeImage)) as FadeImage;
                if(_fade == null)
                {
                    _fade = Instantiate(Resources.Load<FadeImage>("Prefabs/Fade"));
                }
            }

            return _fade;
        }
    }

    private void Awake()
    {
        Screen.SetResolution(1080, 1920, true);
    }

    private void Start()
    {
        Fade.fadeSpeed = 0.8f;

        DontDestroyOnLoad(gameObject);
    }

    private void LoadLevelScene()
    {
        
    }
}
