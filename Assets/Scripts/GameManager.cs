using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private FadeScreen _fade;
    private FadeScreen Fade
    {
        get
        {
            if(_fade == null)
            {
                _fade = GameObject.FindObjectOfType(typeof(FadeScreen)) as FadeScreen;
                if(_fade == null)
                {
                    _fade = Instantiate(Resources.Load<FadeScreen>("Prefabs/Fade"));
                }
            }

            return _fade;
        }
    }

    private void Start()
    {
        Fade.fadeSpeed = 0.8f;

        DontDestroyOnLoad(gameObject);
    }
}
