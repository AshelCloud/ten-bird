using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public GameObject active;
    public Text firewoodText;
    public GameObject beQuiet;

    private void Start()
    {
        SoundManager.Instance.PlayLoop(Resources.Load<AudioClip>("Sounds/game_background"));
    }

    private void Update()
    {
        int activeWoodCnt = 0;
        var woods = GameObject.FindGameObjectsWithTag("Firewood");

        if(woods.Length == 0) { return; }

        for(int i = 0; i < woods.Length; i ++)
        {
            if(woods[i].GetComponent<Firewood>().isActive)
            {
                activeWoodCnt ++;
            }
        }

        firewoodText.text = activeWoodCnt.ToString() + "/" + woods.Length.ToString();

        if(woods.Length == activeWoodCnt)
        {
            GameManager.Instance.isAllActiveWood = true;
        }
        else
        {
            GameManager.Instance.isAllActiveWood = false;
        }
    }
}
