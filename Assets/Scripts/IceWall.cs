using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour, IEventable
{
    public float meltTime = 3f;

    public void ActiveEvent()
    {
    }

    private IEnumerator Melt(float t)
    {
        yield return new WaitForSeconds(t);

        ActiveEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Melt(meltTime));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }
}
