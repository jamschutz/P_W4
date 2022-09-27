using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ElevatorController : MonoBehaviour
{
    public float travelTime;
    public float height;
    public float waitTime;
    public AnimationCurve moveCurve;
    public bool isGoingUp;


    float timer;
    float startingHeight;
    float endingHeight;
    Rigidbody rb;

    void Start()
    {
        timer = 0;
        startingHeight = transform.position.y;
        endingHeight = startingHeight + height;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer < travelTime) {
            float start = isGoingUp? startingHeight : endingHeight;
            float end = isGoingUp? endingHeight : startingHeight;
            float newHeight = Mathf.Lerp(start, end, moveCurve.Evaluate(timer / travelTime));
            rb.MovePosition(new Vector3(transform.position.x, newHeight, transform.position.z));
        }
        
        if(timer >= travelTime + waitTime) {
            isGoingUp = !isGoingUp;
            timer = 0;
        }
    }
}
