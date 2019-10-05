using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anivia : MonoBehaviour
{
    public List<Waypoint> waypoints;
    private Waypoint target;
    public int index = 0;
    private int dir = 1;

    private Rigidbody rb;

    public float speed = 1f;
    public float minDist = 1f;

    private void Awake()
    {
        index = 0;
        target = waypoints[index];
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateAgent();
        
        if(Vector3.Distance(target.transform.position, transform.position) < minDist)
        {
            SetNextTarget();
        }
    }

    private void UpdateAgent()
    {
        Transform t = target.transform;
        t.position = new Vector3(t.position.x, transform.position.y, t.position.z);

        transform.LookAt(t);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void SetNextTarget()
    {
        index += dir;

        if(index >= waypoints.Count)
        {
            dir = -1;
        }
        else if(index < 0)
        {
            dir = 1;
        }
        else
        {
            target = waypoints[index];
            return;
        }

        index += dir;
        target = waypoints[index];
    }
}
