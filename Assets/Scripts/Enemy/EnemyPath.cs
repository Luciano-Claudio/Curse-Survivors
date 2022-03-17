using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    private GameObject player;

    private NavMeshAgent agent;
    private Rigidbody2D rb;

    private float _distToPlayer;

    public float speed { get; set; }
    public float range { get; set; }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
    }

    void Update()
    {
        _distToPlayer = Vector2.Distance(transform.position, player.transform.position);
    }

    void FixedUpdate()
    {
        if(_distToPlayer > range)
            Walking();
    }

    void Walking()
    {
        float x = player.transform.position.x - transform.position.x;
        float y = player.transform.position.y - transform.position.y;
        Vector2 pos = new Vector2(x, y);
        pos = pos.normalized;
        if (Physics2D.Raycast(transform.position, pos, _distToPlayer, 1 << LayerMask.NameToLayer("Environment")))
        {
            //Debug.Log("Something is in the way");
            WasCollision();
            return;
        }
        agent.isStopped = true;

        pos = new Vector2(pos.x * speed, pos.y * speed);

        //Debug.Log(pos);
        rb.velocity = pos;
    }

    void WasCollision()
    {
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, player.transform.position);
    }*/

}
