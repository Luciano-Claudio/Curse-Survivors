using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerArea : MonoBehaviour
{
    [SerializeField] private float hitRange;
    private Animator anim;
    private LayerMask m_WhatIsMob;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        m_WhatIsMob = LayerMask.GetMask("Mobs");
    }

    void Update()
    {

    }

    public void Hit()
    {
        anim.Play("testhit");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, hitRange, m_WhatIsMob);
        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit" + enemy.name);
            Destroy(enemy.transform.parent.gameObject);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, hitRange);
    }
}
