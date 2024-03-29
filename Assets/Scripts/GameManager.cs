﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isAllActiveWood { get; set; }
    public bool isStart { get; set; }

    private void Awake()
    {
        isStart = false;
        isAllActiveWood = false;
        Screen.SetResolution(1080, 1920, true);

        DontDestroyOnLoad(gameObject);
    }

    public void FadeOut()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/FadeOut"));
    }

    public void FadeAndLoadMainScene()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/FadeIn"));
        SoundManager.Instance.PlayLoop(Resources.Load<AudioClip>("Sounds/suzaku"));
    }

    public void LoadLevelScene(int level)
    {
        isAllActiveWood = false;
        StartCoroutine(LoadYourAsyncScene(level));
    }

    public void SetBequite(bool onoff)
    {
        GameCanvas canvas = GameObject.Find("Canvas").GetComponent<GameCanvas>();

        canvas.beQuiet.SetActive(onoff);
    }

    public void SetActive(bool onoff)
    {
        GameCanvas canvas = GameObject.Find("Canvas").GetComponent<GameCanvas>();

        canvas.active.SetActive(onoff);
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
