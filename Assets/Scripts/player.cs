using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 startPoint;
    public float speed = 1f;
    public float rotationSpeed = 1f;
    private Rigidbody rb;
    private Vector3 m_CamForward;
    public Animator animator;
    public bool isDeath { get; set; }
    public GameObject meshes;

    public bool isClear {get; set;}

    public GameObject ui;

    private void Awake()
    {
        isClear = false;
        isDeath = false;
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
        if(isDeath || isClear) { return; }

        float h = UltimateJoystick.GetHorizontalAxis("Move");
        float v = UltimateJoystick.GetVerticalAxis("Move");

        m_CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * m_CamForward + h * Camera.main.transform.right * speed;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Nest") && !isClear)
        {
            isClear = true;
            StartCoroutine(Clear(other.transform.position));
        }
    }

    private IEnumerator Clear(Vector3 position)
    {
        GameManager.Instance.GetGameCanvas().beQuiet.SetActive(true);
        GameManager.Instance.GetGameCanvas().active.SetActive(false);
        ui.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        Instantiate(Resources.Load<GameObject>("Prefabs/Egg"), position, Quaternion.identity);
        meshes.SetActive(false);
        GameManager.Instance.GetGameCanvas().beQuiet.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.FadeAndLoadMainScene();
    }


    public void ActiveAttack()
    {
        if (isDeath || isClear) { return; }
        if (animator.GetBool("Attack")) { return; }

        animator.SetBool("Attack", true);
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.45f);

        var bullet = Instantiate(Resources.Load<Bullet>("Prefabs/Bullet"));
        bullet.transform.position = transform.position;
        bullet.SetForward(transform.forward);

        yield return new WaitForSeconds(0.75f);
        
        animator.SetBool("Attack", false);
    }
}

