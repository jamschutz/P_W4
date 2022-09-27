using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public bool justYAxis = false;
    Transform camera;

    float x;
    float z;

    void Start()
    {
        camera = Camera.main.transform;

        x = transform.eulerAngles.x;
        z = transform.eulerAngles.z;
    }


    void Update()
    {
        transform.LookAt(camera);

        if(justYAxis) {
            transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, z);
        }
    }
}
