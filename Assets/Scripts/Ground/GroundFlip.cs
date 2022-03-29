using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFlip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] sprites;
    private int i, u;
    private bool[,] flips = new bool[,] { { false, false }, { false, true }, { true, true }, { true, false } };
    void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    void Start()
    {
        i = u = 0;
        foreach (SpriteRenderer sprite in sprites)
        {
            Flip(sprite);
        }
    }

    void First(SpriteRenderer sprite)
    {
        int x = i;

        sprite.flipX = flips[i, 0];
        sprite.flipY = flips[i, 1];
        while (i == x) i = Random.Range(0, 4);
        u = i;


    }
    void Flip(SpriteRenderer sprite)
    {
        int x = u;

        sprite.flipX = flips[u, 0];
        sprite.flipY = flips[u, 1];
        while (u == x) u = Random.Range(0, 4);
    }

}
