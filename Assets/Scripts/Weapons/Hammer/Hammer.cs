using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private HammerArea[] hammerArea;
    [SerializeField] private float timer;
    [SerializeField] private int hitQuantity;
    private bool inHit;

    void Awake()
    {
        hammerArea = GetComponentsInChildren<HammerArea>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (!inHit)
            StartCoroutine(Hit());
    }

    void Hitting()
    {
        for (int i = 0; i < hitQuantity; i++)
        {
            hammerArea[i].Hit();
        }
    }
    IEnumerator Hit()
    {
        inHit = true;

        Hitting();
        yield return new WaitForSeconds(timer);
        inHit = false;
    }
}
