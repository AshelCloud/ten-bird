using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public GameObject mainObject;
    public GameObject selectObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainObject.SetActive(false);
            selectObject.SetActive(true);
        }
    }
}
