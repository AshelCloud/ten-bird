using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour, IEventable
{
    public void ActiveEvent()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ActiveEvent();
        }
    }
}
