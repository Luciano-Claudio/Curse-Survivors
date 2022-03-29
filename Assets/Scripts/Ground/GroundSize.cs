using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSize : MonoBehaviour
{
    [SerializeField] private GameObject Ground;

    [SerializeField] private float minX;
    [SerializeField] private float minY;



    private float x, y;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        x = minX;
        y = minY;
        for (int u = 0; u < 60; u++)
        {
            for (int i = 0; i < 102; i++)
            {
                pos = new Vector3(x, y, 0);
                Instantiate(Ground, pos, Quaternion.identity);
                x++;
            }
            y++;
            x = minX;
        }
    }

}
