using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponentInChildren<Collider2D>());
    }
}
