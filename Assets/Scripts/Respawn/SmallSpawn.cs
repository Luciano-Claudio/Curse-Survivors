using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Respawn;
    float dist;
    float x, y;
    int k;
    // 30 20
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            k = i == 0 ? 1 : -1;
            x = 20 * k;
            y = 12.5f;
            dist = 25 / 9f;
            int qtd = 10;
            for (int j = 0; j < qtd; j++)
            {
                Vector3 pos = new Vector3(x + Camera.main.transform.position.x, y + Camera.main.transform.position.y, 0);
                Instantiate(Respawn, pos, Quaternion.identity, transform);
                y -= dist;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            k = i == 0 ? 1 : -1;
            x = 20;
            y = 12.5f * k;
            dist = 40 / 14f;
            int qtd = 15;
            for (int j = 0; j < qtd; j++)
            {
                Vector3 pos = new Vector3(x + Camera.main.transform.position.x, y + Camera.main.transform.position.y, 0);
                Instantiate(Respawn, pos, Quaternion.identity, transform);
                x -= dist;
            }
        }
    }
}
