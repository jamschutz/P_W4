using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprites : MonoBehaviour
{
    public Sprite[] sprites;
    public Vector2 animationTimeRange;


    SpriteRenderer renderer;
    float timer;
    float targetTime;
    int sprite;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        timer = 0;
        sprite = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= targetTime) {
            timer = 0;
            sprite = (sprite + 1) % sprites.Length;
            renderer.sprite = sprites[sprite];
            SetTargetTime();
        }
    }



    void SetTargetTime()
    {
        targetTime = Random.Range(animationTimeRange.x, animationTimeRange.y);
    }
}
