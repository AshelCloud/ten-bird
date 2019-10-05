using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public Text firewoodText;

    private void Update()
    {
        int activeWoodCnt = 0;
        var woods = GameObject.FindGameObjectsWithTag("Firewood");

        for(int i = 0; i < woods.Length; i ++)
        {
            if(woods[i].GetComponent<Firewood>().isActive)
            {
                activeWoodCnt ++;
            }
        }

        firewoodText.text = activeWoodCnt.ToString() + "/" + woods.Length.ToString();
            
    }
}
