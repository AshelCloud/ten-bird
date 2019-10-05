using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * 100f * Time.deltaTime;
    }

    public void SetForward(Vector3 forward)
    {
        dir = forward.normalized;
    }
}
