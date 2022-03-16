using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Respawn;
    [SerializeField] private int Qtd;
    [SerializeField] private int Radius;

    [SerializeField] private float ang;

    private float x;
    private float y;
    void Start()
    {
        ang = 2 * Mathf.PI / Qtd;

        for (int i = 1; i < Qtd + 1; i++)
        {
            x = Radius * Mathf.Cos(ang * i);
            y = Radius * Mathf.Sin(ang * i);
            Vector3 pos = new Vector3(x + Camera.main.transform.position.x, y + Camera.main.transform.position.y, 0);

            Instantiate(Respawn, pos, Quaternion.identity, transform);

        }
    }

}
