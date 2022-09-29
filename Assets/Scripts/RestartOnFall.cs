using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{
    public float heightThreshold;


    void Update()
    {
        if(transform.position.y < heightThreshold) {
            SceneManager.LoadScene(1);
        }
    }
}
