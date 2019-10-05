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

    [SerializeField]
    private int hp;
    public int HP
    {
        get
        {
            return hp;            
        }

        set
        {
            hp = value;
            if(hp <= 0)
            {
                isDie = true;
            }
        }
    }

    private bool isDie;

    private void Awake()
    {
        HP = 3;
        isDie = false;
        index = 0;
        target = waypoints[index];
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isDie) { return; }

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActiveDeath(collision));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            HP--;

            if (isDie)
            {
                GetComponent<Animator>().SetBool("Death", true);
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private IEnumerator ActiveDeath(Collision collision)
    {
        collision.gameObject.GetComponent<Player>().animator.SetBool("Death", true);
        collision.gameObject.GetComponent<Player>().isDeath = true;

        yield return new WaitForSeconds(3f);

        GameManager.Instance.FadeAndLoadMainScene();
    }
}
