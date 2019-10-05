using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewood : MonoBehaviour, IEventable
{
    public GameObject fire;

    public void ActiveEvent()
    {
        fire.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ActiveEvent();
        }
    }
}
