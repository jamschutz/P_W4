using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsch
{
    // taken largely from: https://github.com/IronWarrior/SuperCharacterController/blob/master/Assets/SuperCharacterController/Scripts/PlayerCamera.cs
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
    // =============================================================== //
    // =========     Variables              ========================== //
    // =============================================================== //

        // ----- public vars ----------- //
        public Transform player;

        [Header("Sensitivity")]
        public float lookSensitivity;

        [Header("Follow")]
        [Range(0, 1)]
        public float followSpeed = 0.2f;
        public Vector3 followOffset;


        // ----- private vars ----------- //
        private Camera cam;
        // private PlayerInputController input;

        private float yRotation;
        private float xRotation;
        private Vector3 lookDirection;

        // helpers
        private float inverseFollowSpeed;




    // =============================================================== //
    // =========     Lifecycle Methods      ========================== //
    // =============================================================== //

        void Start()
        {
            cam = GetComponent<Camera>();
            // input = player.gameObject.GetComponent<PlayerInputController>();
            inverseFollowSpeed = 1.0f - followSpeed;
            yRotation = transform.eulerAngles.y;
            xRotation = transform.eulerAngles.x;
            lookDirection = player.forward;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }


        void LateUpdate()
        {
            RotateCamera();
            return;
        }


        void RotateCamera()
        {
            // set position to player
            transform.position = player.position;

            // rotate based on input
            // xRotation -= input.Current.Camera.y * input.mouseSensitivity.x * Time.deltaTime;
            // yRotation += input.Current.Camera.x * input.mouseSensitivity.y * Time.deltaTime;

            if(Input.GetKey(KeyCode.I)) {
                xRotation += lookSensitivity * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.J)) {
                yRotation -= lookSensitivity * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.K)) {
                xRotation -= lookSensitivity * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.L)) {
                yRotation += lookSensitivity * Time.deltaTime;
            }

            transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
            

            // move camera
            transform.position = transform.position - (transform.forward * followOffset.z); // z axis 
            transform.position = transform.position + (Vector3.up * followOffset.y); // y axis
        }
    }
}