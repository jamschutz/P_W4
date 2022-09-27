using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    public float waitTime;

    Rigidbody rb;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            Debug.Log($"{name} got player at {Time.time}");
            rb.useGravity = false;
            Invoke("ActivateGravity", waitTime);
        }
    }


    void ActivateGravity()
    {
        Debug.Log($"{name} activating gravity at {Time.time}");
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}
