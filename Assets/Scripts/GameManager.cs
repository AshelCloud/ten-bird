using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
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

    public void LoadLevelScene(int level)
    {
        StartCoroutine(LoadYourAsyncScene(level));
    }

    private IEnumerator LoadYourAsyncScene(int level)
    {
        var stage = Resources.Load<GameObject>("Prefabs/Stages/Stage0" + level.ToString());
        var pheonix = Resources.Load<GameObject>("Prefabs/Phoenix");

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Instantiate(stage);
        Instantiate(pheonix);
    }
}
