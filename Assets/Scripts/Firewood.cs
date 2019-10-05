using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewood : MonoBehaviour, IEventable
{
    public GameObject fire;

    public void ActiveEvent()
    {
        SoundManager.Instance.PlayClip(Resources.Load<AudioClip>("Sounds/firewood_Firing"));
        fire.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag("Player"))
        {
            ActiveEvent();
        }
    }
}
