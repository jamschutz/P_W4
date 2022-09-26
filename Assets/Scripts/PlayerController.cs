using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;


    private Vector3 moveInput;
    private Rigidbody rb;
    private Transform camera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveInput = Vector3.zero;
        camera = Camera.main.transform;
    }


    void Update()
    {
        if(moveInput != Vector3.zero) return;

        if(Input.GetKey(KeyCode.W)) {
            moveInput += camera.forward;
        }
        if(Input.GetKey(KeyCode.A)) {
            moveInput -= camera.right;
        }
        if(Input.GetKey(KeyCode.S)) {
            moveInput -= camera.forward;
        }
        if(Input.GetKey(KeyCode.D)) {
            moveInput += camera.right;
        }
    }


    void FixedUpdate()
    {
        rb.AddForce(moveInput.normalized * speed);
        moveInput = Vector3.zero;
    }
}
