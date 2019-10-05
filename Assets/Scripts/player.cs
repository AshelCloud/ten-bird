using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 startPoint;
    public float Spend = 1f;
    public float rotationSpeed = 1f;
    private Rigidbody rb;
    private Vector3 m_CamForward;
    public Animator animator;

    private void Awake()
    {
        startPoint = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        m_CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
    }

    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform.position;
        startPoint.y = 0.2f;
        transform.position = startPoint;
    }

    void FixedUpdate()
    {
        float h = UltimateJoystick.GetHorizontalAxis("Move");
        float v = UltimateJoystick.GetVerticalAxis("Move");

        m_CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * m_CamForward + h * Camera.main.transform.right;
        if(move == Vector3.zero)
        {
            animator.SetBool("Move", false);    
        }
        else
        {
            animator.SetBool("Move", true);
        }

        rb.velocity = move;

        
        transform.Rotate(0f, h * rotationSpeed * Time.deltaTime, 0f);
    }
}

