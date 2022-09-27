using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float timeToSlow;


    private Vector3 moveInput;
    private Rigidbody rb;
    private Transform camera;

    private float maxSpeed;
    private float minSpeed;
    private float timer;
    private Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveInput = Vector3.zero;
        camera = Camera.main.transform;

        maxSpeed = speed;
        minSpeed = 0;
        timer = 0;
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


        // recharge
        timer += Time.deltaTime;
        if(Input.GetKey(KeyCode.Space)) {
            speed = maxSpeed;
            timer = 0;
        }
        else {
            speed = Mathf.Lerp(maxSpeed, minSpeed, timer / timeToSlow);
        }


        if(Input.GetKeyDown(KeyCode.Space)) {
            velocity = rb.velocity;
            rb.velocity = Vector3.zero;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            rb.velocity = velocity;
        }
    }


    void FixedUpdate()
    {
        rb.AddForce(moveInput.normalized * speed);
        moveInput = Vector3.zero;
    }
}
