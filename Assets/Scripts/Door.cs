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
        StartCoroutine(WaitActiveWood());
    }

    private IEnumerator WaitActiveWood()
    {
        yield return new WaitUntil( () => GameManager.Instance.isAllActiveWood == true);

        ActiveEvent();
    }

    public void ActiveEvent()
    {
        SoundManager.Instance.PlayClip(Resources.Load<AudioClip>("Sounds/door_open"));
        Anima.SetBool("Open", true);
    }
}
