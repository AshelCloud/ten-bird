﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewood : MonoBehaviour, IEventable
{
    public GameObject fire;
    public bool isActive { get; set; }

    private void Start()
    {
        isActive = false;
    }

    public void ActiveEvent()
    {
        SoundManager.Instance.PlayClip(Resources.Load<AudioClip>("Sounds/firewood_Firing"));
        fire.SetActive(true);
        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ActiveEvent();
        }
    }
}
