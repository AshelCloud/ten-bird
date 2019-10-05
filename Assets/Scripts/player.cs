using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Spend = 1f;
    private Vector3 startPoint;

    private void Awake()
    {
        startPoint = Vector3.zero;
    }

    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform.position;
        transform.position = startPoint;
    }

    void Update()
    {
    }
}

