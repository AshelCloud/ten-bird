using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IEventable
{
    private Animator _anima;
    public Animator Anima
    {
        get
        {
            if(_anima == null)
            {
                _anima = GetComponent<Animator>();
            }
            return _anima;
        }
    }

    private void Start()
    {
    }

    public void ActiveEvent()
    {
        Anima.SetBool("Open", true);
    }
}
