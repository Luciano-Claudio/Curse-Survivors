using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    private GameObject player;

    private NavMeshAgent agent;
    private Rigidbody2D rb;
    private CircleCollider2D col;

    private float _distToPlayer;
    private bool navMesh = false;
    private bool walk = false;

    public float speed { get; set; }
    public float range { get; set; }
    public float radius { get; set; }
    public bool nonColision { get; set; }
    Vector2 pos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        player = GameObject.Find("Player");

        if (!nonColision)
            agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        //_distToPlayer = Vector2.Distance(transform.position, player.transform.position);
    }

    void Update()
    {
        Vector3 aux = new Vector3(transform.position.x - col.offset.x, transform.position.y - col.offset.y, transform.position.z);
        _distToPlayer = Vector2.Distance(aux, player.transform.position);
    }

    void FixedUpdate()
    {
        float x = player.transform.position.x - transform.position.x;
        float y = player.transform.position.y - transform.position.y;
        pos = new Vector2(x, y);
        pos = pos.normalized;

        if (_distToPlayer > range)
            Walking();
    }

    void Walking()
    {

        if (Physics2D.Raycast(transform.position, pos, _distToPlayer, 3 << LayerMask.NameToLayer("Environment")) && !nonColision)
        {
            //Debug.Log("Something is in the way");
            WasCollision();
            return;
        }
        else if (navMesh)
        {
            navMesh = false;
            agent.isStopped = true;
            agent.radius = 0;
        }


        pos = new Vector2(pos.x * speed, pos.y * speed);
        //Debug.Log(pos);
        StartCoroutine(Velocity(pos));
    }

    void WasCollision()
    {
        navMesh = true;
        agent.radius = radius;
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
    }


    private IEnumerator Velocity(Vector2 pos)
    {
        walk = true;
        yield return new WaitForSeconds(.1f);
        rb.velocity = pos;
        walk = false;
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, player.transform.position);
        Gizmos.DrawSphere(transform.position, range);
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pos = new Vector2(pos.x * speed, pos.y * speed);
            rb.velocity = -pos;
        }
    }
}
