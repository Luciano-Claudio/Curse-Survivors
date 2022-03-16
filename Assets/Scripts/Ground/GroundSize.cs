using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSize : MonoBehaviour
{
    [SerializeField] private GameObject Ground;

    [SerializeField] private float x = 47.5f;
    [SerializeField] private float y = 47.5f;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 96; i++)
        {
            for (int j = 0; j < 96; j++)
            {
                pos = new Vector3(x, y, 0);
                Instantiate(Ground, pos, Quaternion.identity, transform);
                x -= 1;
            }
            x = 47.5f;
            y -= 1f;
        }
    }

}
