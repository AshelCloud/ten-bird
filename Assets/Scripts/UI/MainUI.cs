﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject selectObject;

    private void Start()
    {
        if(GameManager.Instance.isStart)
        {
            LoadSelect();
            GameManager.Instance.FadeOut();
        }
        else
        {
            GameManager.Instance.isStart = true;
        }
    }

    public void LoadSelect()
    {
        mainObject.SetActive(false);
        selectObject.SetActive(true);
    }

    public void ShowCredit()
    {
        
    }
}
