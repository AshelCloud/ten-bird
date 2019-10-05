using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject selectObject;

    public void LoadSelect()
    {
        mainObject.SetActive(false);
        selectObject.SetActive(true);
    }

    public void ShowCredit()
    {
        
    }
}
