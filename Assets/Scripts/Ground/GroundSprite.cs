using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spritesRend;
    [SerializeField] private Sprite[] sprites;
    void Awake()
    {
        spritesRend = GetComponentsInChildren<SpriteRenderer>();
    }
    void Start()
    {
        foreach(SpriteRenderer sprite in spritesRend)
        {
            ChangeSprite(sprite);
        }
    }

    void ChangeSprite(SpriteRenderer sprite)
    {
        int i = Random.Range(0, 160);

        while (i > 15) i -= 4;


        sprite.sprite = sprites[i];

    }
}
