using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Spend = 15.0f;
    float h = 0.0f;
    Vector3 dir;
    private Transform mytransform = null;

    public GameObject bird_idle = null;
    // Start is called before the first frame update
    void Start()
    {
        mytransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        dir = new Vector3(h, 0, 0);

        transform.position += dir * Spend * Time.deltaTime;
        
        
    }
}

