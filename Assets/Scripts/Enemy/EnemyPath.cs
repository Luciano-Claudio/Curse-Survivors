using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{

    private NavMeshAgent agent;
    private Rigidbody2D rb;

    private CapsuleCollider2D _playerCollider;
    private LayerMask m_WhatIsPlayer;
    private LayerMask m_WhatIsEnvironment;

    private float _distToPlayer;
    private bool navMesh = false;
    private bool walk = false;
    private bool stop = false;


    public float speed { get; set; }
    public float range { get; set; }
    public float size { get; set; }
    public bool nonColision { get; set; }

    public CircleCollider2D _collider;

    Vector2 pos;

    Vector3 _colliderPos;
    Vector3 _playerColliderPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _collider = GetComponentInChildren<CircleCollider2D>();


        if (!nonColision)
            agent = GetComponent<NavMeshAgent>();

        _playerCollider = GameObject.Find("Player").GetComponentInChildren<CapsuleCollider2D>();
    }
    void Start()
    {
        m_WhatIsPlayer = LayerMask.GetMask("Player");
        m_WhatIsEnvironment = LayerMask.GetMask("Environment");
    }

    void Update()
    {
        _playerColliderPos = new Vector3(_playerCollider.transform.position.x, _playerCollider.transform.position.y, _playerCollider.transform.position.z);

        _colliderPos = new Vector3(_collider.transform.position.x, _collider.transform.position.y, _collider.transform.position.z);

        _distToPlayer = Vector2.Distance(_colliderPos, _playerColliderPos);
        

        float x = _playerColliderPos.x - _colliderPos.x;
        float y = _playerColliderPos.y - _colliderPos.y;
        pos = new Vector2(x, y);
        pos = pos.normalized;
       
        stop = Physics2D.OverlapCircle(_colliderPos, _collider.radius * size + .01f, m_WhatIsPlayer) ? true : false;
    }

    void FixedUpdate()
    {
        if (_distToPlayer > range && !stop)
            Walking();
    }

    void Walking()
    {

        if (Physics2D.Raycast(transform.position, pos, _distToPlayer, m_WhatIsEnvironment) && !nonColision)
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

        if(!walk) 
            StartCoroutine(Velocity(pos));
    }

    void WasCollision()
    {
        navMesh = true;
        agent.radius = _collider.radius;
        agent.isStopped = false;
        agent.SetDestination(_playerColliderPos);
    }


    private IEnumerator Velocity(Vector2 pos)
    {
        walk = true;
        yield return new WaitForSeconds(.1f);
        rb.velocity = pos;
        walk = false;
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_colliderPos, _playerColliderPos);
        Gizmos.DrawWireSphere(_colliderPos, _collider.radius * size + .05f);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Mobs"))
            rb.velocity = Vector2.zero;
    }*/
}
