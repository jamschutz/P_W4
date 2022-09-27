using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;

    Vector3 offset;
    void Start()
    {
        offset = transform.position - ball.position;
    }

    void Update()
    {
        transform.position = ball.position + offset;
    }
}
